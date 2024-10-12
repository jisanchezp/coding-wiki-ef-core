using CodingWiki.DataAccess.Data;
using CodingWiki.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodingWiki.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            List<Category> categories = _db.Categories.ToList();

            return View(categories);
        }

        public IActionResult Upsert(int id)
        {
            Category category = new();

            if (id == null || id == 0)
            {
                //create
                return View(category);
            }

            category = _db.Categories.First(c => c.Id == id);

            if (category == null)
            {                
                return NotFound();
            }
            return View(category);
        }
    }
}
