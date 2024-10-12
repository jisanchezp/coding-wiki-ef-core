using CodingWiki.DataAccess.Data;
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
    }
}
