using CodingWiki.DataAccess.Data;
using CodingWiki.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodingWiki.Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AuthorController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var authors = _db.Authors.ToList();

            return View(authors);
        }

        public IActionResult Upsert(int? id)
        {
            Author? author = new();

            if (id == null || id == 0)
            {
                return View(author);
            }

            author = _db.Authors.FirstOrDefault(a => a.AuthorId == id);

            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Author author)
        {
            if (ModelState.IsValid)
            {
                if (author.AuthorId == 0)
                {
                    await _db.Authors.AddAsync(author);
                }
                else
                {
                    _db.Authors.Update(author);
                }

                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(author);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Author? author = await _db.Authors.FindAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            _db.Authors.Remove(author);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
