using CodingWiki.DataAccess.Data;
using CodingWiki.Model.Models;
using CodingWiki.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace CodingWiki.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            //List<Book> books = _db.Books.Include(b => b.Publisher).ToList();
            List<Book> books = _db.Books.ToList();

            foreach (var book in books)
            {
                // Least efficient
                // book.Publisher = await _db.Publishers.FindAsync(book.PublisherId);

                // More efficient
                await _db.Entry(book).Reference(b => b.Publisher).LoadAsync();
                await _db.Entry(book).Collection(b => b.BookAuthorMap).LoadAsync();

                foreach (var bookAuthor in book.BookAuthorMap)
                {
                    await _db.Entry(bookAuthor).Reference(b => b.Author).LoadAsync();
                }
            }

            return View(books);
        }

        public IActionResult Upsert(int? bookId)
        {
            BookVM? bookVM = new();

            bookVM.PublisherList = _db.Publishers
                .Select(p => new SelectListItem
                {
                    Text = p.Name,
                    Value = p.PublisherId.ToString()
                });

            if (bookId == null || bookId == 0)
            {
                return View(bookVM);
            }

            bookVM.Book = _db.Books.FirstOrDefault(b => b.BookId == bookId);

            if (bookVM.Book == null)
            {
                return NotFound();
            }

            return View(bookVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(BookVM bookVM)
        {
            if (ModelState.IsValid)
            {
                if (bookVM.Book.BookId == 0)
                {
                    await _db.Books.AddAsync(bookVM.Book);
                }
                else
                {
                    _db.Books.Update(bookVM.Book);
                }

                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(bookVM);
        }

        public IActionResult Details(int? bookId)
        {
            if (bookId == null || bookId == 0)
            {
                return NotFound();
            }

            BookDetail? bookDetails = _db.BookDetails.Include(d => d.Book).ThenInclude(b => b.BookAuthorMap).FirstOrDefault(d => d.BookId == bookId);

            if (bookDetails == null)
            {
                bookDetails = new();
                bookDetails.Book = _db.Books.FirstOrDefault(b => b.BookId == bookId);
            }            

            return View(bookDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(BookDetail bookDetail)
        {
            if (bookDetail.BookDetailId == 0)
            {
                await _db.BookDetails.AddAsync(bookDetail);
            }
            else
            {
                bookDetail.Book = null;
                _db.BookDetails.Update(bookDetail);
            }

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int bookId)
        {
            Book? book = _db.Books.FirstOrDefault(b => b.BookId == bookId);

            if (book == null)
            {
                return NotFound();
            }

            _db.Books.Remove(book);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ManageAuthors(int bookId)
        {
            BookAuthorVM bookAuthorVM = new()
            {
                BookAuthorList = _db.BookAuthorMaps.Include(u => u.Author).Include(u => u.Book)
                    .Where(m => m.BookId == bookId).ToList(),
                BookAuthor = new()
                {
                    BookId = bookId,
                },
                Book = _db.Books.FirstOrDefault(b => b.BookId == bookId)
            };

            List<int> tempListOfAssignedAuthor = bookAuthorVM.BookAuthorList.Select(a => a.AuthorId).ToList();
            List<Author> notAssignedAuthors = _db.Authors.Where(a => tempListOfAssignedAuthor.Contains(a.AuthorId) == false).ToList();
            bookAuthorVM.AuthorList = notAssignedAuthors.Select(a =>
                new SelectListItem 
                {
                    Value = a.AuthorId.ToString(),
                    Text = a.FullName
                });

            return View(bookAuthorVM);
        }

        [HttpPost]
        public IActionResult ManageAuthors(BookAuthorVM bookAuthorVM)
        {
            if (bookAuthorVM.BookAuthor.BookId != 0 && bookAuthorVM.BookAuthor.AuthorId != 0)
            {
                _db.BookAuthorMaps.Add(bookAuthorVM.BookAuthor);
                _db.SaveChanges();
            }

            return RedirectToAction(nameof(ManageAuthors), new { @bookId = bookAuthorVM.BookAuthor.BookId });
        }

        [HttpPost]
        public IActionResult RemoveAuthor(int authorId, BookAuthorVM bookAuthorVM)
        {
            int bookId = bookAuthorVM.Book.BookId;
            BookAuthorMap bookAuthorMap = _db.BookAuthorMaps.FirstOrDefault(m => m.AuthorId == authorId && m.BookId == bookId);

            if (bookAuthorMap == null)
            {
                return NotFound();
            }

            _db.BookAuthorMaps.Remove(bookAuthorMap);
            _db.SaveChanges();

            return RedirectToAction(nameof(ManageAuthors), new { bookId });
        }

        public async Task<IActionResult> PlayGround()
        {
            IEnumerable<Book> bookList1 = _db.Books;
            var filteredBookList1 = bookList1.Where(b => b.Price > 50);

            IQueryable<Book> bookList2 = _db.Books;
            var filteredBookList2 = bookList2.Where(b => b.Price > 50);

            var f1 = filteredBookList1.ToList();
            var f2 = filteredBookList2.ToList();

            var bookTemp = _db.Books.FirstOrDefault();
            bookTemp.Price = 100;

            var bookCollection = _db.Books;
            decimal totalPrice = 0;

            foreach (var book in bookCollection)
            {
                totalPrice += book.Price;
            }

            var bookList = _db.Books.ToList();
            foreach (var book in bookList)
            {
                totalPrice += book.Price;
            }

            var bookCollection2 = _db.Books;
            var bookCount1 = bookCollection2.Count();

            var bookCount2 = _db.Books.Count();

            return RedirectToAction(nameof(Index));
        }
    }
}
