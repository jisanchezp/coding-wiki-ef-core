using CodingWiki.DataAccess.Data;
using CodingWiki.Model.Models;
using CodingWiki.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            List<Book> books = _db.Books.ToList();

            foreach (var book in books)
            {
                // Least efficient
                //book.Publisher = await _db.Publishers.FindAsync(book.PublisherId);

                // More efficient
                await _db.Entry(book).Reference(b => b.Publisher).LoadAsync();
            }

            return View(books);
        }

        public IActionResult Upsert(int? id)
        {
            BookVM? bookVM = new();

            bookVM.PublisherList = _db.Publishers
                .Select(p => new SelectListItem
                {
                    Text = p.Name,
                    Value = p.Id.ToString()
                });

            if (id == null || id == 0)
            {
                return View(bookVM);
            }

            bookVM.Book = _db.Books.FirstOrDefault(b => b.Id == id);

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
                if (bookVM.Book.Id == 0)
                {
                    await _db.Books.AddAsync(bookVM.Book);
                }
                else
                {
                    _db.Update(bookVM.Book);
                }

                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(bookVM);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Book? book = _db.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            _db.Books.Remove(book);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
