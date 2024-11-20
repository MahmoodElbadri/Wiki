using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wiki.DataAccess.Data;
using Wiki.Model.Models;

namespace Wiki.Web.Controllers;
public class BookController : Controller
{
    private readonly ApplicationDbContext _db;
    public BookController(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<IActionResult> Index()
    {
        List<Book> books = await _db.Books.ToListAsync();
        return View(books);
    }
    public async Task<IActionResult> Upsert(int? id)
    {
        Book? book = new();
        if (id == 0 || id == null)
        {
            return View(book);
        }
        else
        {
            book = await _db.Books.FirstOrDefaultAsync(tmp => tmp.Book_Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Upsert(Book book)
    {
        if (ModelState.IsValid)
        {
            if (book.Book_Id == 0)
            {
                await _db.Books.AddAsync(book);
            }
            else
            {
                _db.Update(book);
            }
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(book);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        Book? book = _db.Books.FirstOrDefault(tmp => tmp.Book_Id == id);
        if (book == null)
        {
            return NotFound();
        }
        _db.Books.Remove(book);
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
