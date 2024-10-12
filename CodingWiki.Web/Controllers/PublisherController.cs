using CodingWiki.DataAccess.Data;
using CodingWiki.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingWiki.Web.Controllers
{
    public class PublisherController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PublisherController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Publisher> publishers = _db.Publishers.ToList();

            return View(publishers);
        }

        public IActionResult Upsert(int? id)
        {
            Publisher? publisher = new();

            if (id == null || id == 0)
            {
                return View(publisher);
            }

            publisher = _db.Publishers.FirstOrDefault(p => p.Id == id);

            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }
    }
}
