using CodingWiki.DataAccess.Data;
using CodingWiki.Model.Models;
using Microsoft.AspNetCore.Mvc;

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
                // create
                return View(author);
            }

            author = _db.Authors.FirstOrDefault(a => a.Id == id);

            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }
    }
}
