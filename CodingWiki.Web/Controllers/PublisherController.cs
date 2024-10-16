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

            publisher = _db.Publishers.FirstOrDefault(p => p.PublisherId == id);

            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                if (publisher.PublisherId == 0)
                {
                    await _db.Publishers.AddAsync(publisher);
                }
                else
                {
                    _db.Publishers.Update(publisher);
                }

                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(publisher);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Publisher? publisher = _db.Publishers.FirstOrDefault(p => p.PublisherId == id);

            if (publisher == null)
            {
                return NotFound();
            }

            _db.Publishers.Remove(publisher);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
