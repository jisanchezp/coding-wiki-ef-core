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

        public IActionResult Upsert(int? id)
        {
            Category category = new();

            if (id == null || id == 0)
            {
                return View(category);
            }
            
            category = _db.Categories.FirstOrDefault(c => c.Id == id)!;

            if (category == null)
            {
                
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.Id == 0)
                {
                    // create
                    await _db.Categories.AddAsync(category);
                }
                else
                {
                    // update
                    _db.Categories.Update(category);
                }

                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Category category = _db.Categories.FirstOrDefault(c => c.Id == id)!;
            if (category == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateMultiple2()
        {
            for (int i = 1; i <= 2; i++)
            {
                await _db.Categories.AddAsync(new Category { CategoryName = Guid.NewGuid().ToString() });
            }

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateMultiple5()
        {
            List<Category> categories = new();

            for (int i = 1; i <= 5; i++)
            {
                categories.Add(new Category { CategoryName = Guid.NewGuid().ToString() });
            }

            await _db.Categories.AddRangeAsync(categories);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
