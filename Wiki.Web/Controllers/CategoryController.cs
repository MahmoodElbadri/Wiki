using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wiki.DataAccess.Data;
using Wiki.Model.Models;

namespace Wiki.Web.Controllers;
public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;
    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<IActionResult> Index()
    {
        List<Category> categories = await _db.Categories.ToListAsync();
        return View(categories);
    }
    public async Task<IActionResult> Upsert(int? id)
    {
        Category? category = new();
        if (id == 0 || id == null)
        {
            return View(category);
        }
        else
        {
            category = await _db.Categories.FirstOrDefaultAsync(tmp => tmp.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Upsert(Category category)
    {
        if (ModelState.IsValid)
        {
            if (category.CategoryId == 0)
            {
                await _db.Categories.AddAsync(category);
            }
            else
            {
                _db.Update(category);
            }
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(category);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        Category? category = _db.Categories.FirstOrDefault(tmp => tmp.CategoryId == id);
        if (category == null)
        {
            return NotFound();
        }
        _db.Categories.Remove(category);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult CreateMultiple2()
    {
        List<Category> categories = new List<Category>();
        for (int i = 0; i < 2; i++)
        {
            categories.Add(new Category { CategoryName = Guid.NewGuid().ToString() });
        }
        _db.Categories.AddRange(categories);
        _db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    public IActionResult CreateMultiple5()
    {
        List<Category> categories = new List<Category>();
        for (int i = 0; i < 5; i++)
        {
            categories.Add(new Category { CategoryName = Guid.NewGuid().ToString() });
        }
        _db.Categories.AddRange(categories);
        _db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    public IActionResult RemoveMultiple2()
    {
        List<Category> categories = _db.Categories.Take(2).ToList();
        _db.Categories.RemoveRange(categories);
        _db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult RemoveMultiple5()
    {
        List<Category> categories = _db.Categories.Take(5).ToList();
        _db.Categories.RemoveRange(categories);
        _db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
