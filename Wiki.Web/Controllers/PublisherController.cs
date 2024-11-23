using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wiki.DataAccess.Data;
using Wiki.Model.Models;

namespace Wiki.Web.Controllers;

#nullable disable
public class PublisherController : Controller
{
    private readonly ApplicationDbContext _db;
    public PublisherController(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<IActionResult> Index()
    {
        List<Publisher> Publishers = await _db.Publishers.ToListAsync();
        return View(Publishers);
    }

    public async Task<IActionResult> Upsert(int? id)
    {
        Publisher Publisher = new();
        if (id == null || id == 0)
        {
            return View(Publisher);
        }

        Publisher = await _db.Publishers.FirstOrDefaultAsync(tmp => tmp.Publisher_Id == id);
        if (Publisher == null)
        {
            return NotFound();
        }
        return View(Publisher);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Upsert(Publisher Publisher)
    {
        if (ModelState.IsValid)
        {
            if (Publisher.Publisher_Id == 0)
            {
                await _db.Publishers.AddAsync(Publisher);
            }
            else
            {
                _db.Publishers.Update(Publisher);
            }
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(Publisher);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        var Publisher = await _db.Publishers.FirstOrDefaultAsync(tmp => tmp.Publisher_Id == id);
        if (Publisher == null)
        {
            return NotFound();
        }
        _db.Publishers.Remove(Publisher);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
