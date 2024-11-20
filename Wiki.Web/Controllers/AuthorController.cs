using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wiki.DataAccess.Data;
using Wiki.Model.Models;

namespace Wiki.Web.Controllers;
public class AuthorController : Controller
{
    private readonly ApplicationDbContext _db;
    public AuthorController(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<IActionResult> Index()
    {
        List<Author> authors = await _db.Authors.ToListAsync();
        return View(authors);
    }

    public async Task<IActionResult> Upsert(int? id)
    {
        Author? author = new();
        if (id == null || id == 0)
        {
            return View(author);
        }
        
        author = await _db.Authors.FirstOrDefaultAsync(tmp => tmp.Author_Id == id);
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
            if (author.Author_Id == 0)
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

    public async Task<IActionResult> Delete(int? id)
    {
        var author = await _db.Authors.FirstOrDefaultAsync(tmp => tmp.Author_Id == id);
        if (author == null)
        {
            return NotFound();
        }
        _db.Authors.Remove(author);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
