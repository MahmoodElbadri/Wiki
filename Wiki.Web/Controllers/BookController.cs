using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wiki.DataAccess.Data;
using Wiki.Model.Models;
using Wiki.Web.ViewModels;
using System.Linq;

namespace Wiki.Web.Controllers;

#nullable disable
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
        //foreach (Book book in books)
        {
            //book.Publisher = await _db.Publishers.FindAsync(book.Publisher_Id);
            //await _db.Entry(book).Reference(tmp => tmp.Publisher).LoadAsync();
            await _db.Books.Include(tmp=>tmp.Publisher).ToListAsync();
        }
        return View(books);
    }

    public IActionResult ManageAuthors(int? id)
    {
        BookAuthorVM obj = new()
        {
            BookAuthorList = _db.BookAuthorMaps.Include(tmp => tmp.Author).Where(tmp => tmp.Book_Id == id).ToList(),
            BookAuthor = new()
            {
                Book_Id = id??0,
            },
            Book = _db.Books.FirstOrDefault(tmp => tmp.Book_Id == id),
        };
        List<int> tempListOfAssignedAuthorIds = _db.Authors.Where(tmp => obj.BookAuthorList.Any(tmp2 => tmp2.Author_Id == tmp.Author_Id))
            .Select(tmp => tmp.Author_Id).ToList();

        //_db.BookAuthorMaps.Where(tmp => tmp.Book_Id == id).Select(tmp => tmp.Author_Id).ToList();
        var tempList = _db.Authors.Where(tmp => !tempListOfAssignedAuthorIds.Contains(tmp.Author_Id)).ToList();
        obj.AuthorList = tempList.Select(tmp => new SelectListItem
        {
            Text = tmp.FullName,
            Value = tmp.Author_Id.ToString()
        });
        return View(obj);
    }

    public async Task<IActionResult> Upsert(int? id)
    {
        BookVM obj = new();
        obj.PublisherList = _db.Publishers.Select(tmp => new SelectListItem
        {
            Text = tmp.Name,
            Value = tmp.Publisher_Id.ToString()
        });
        if (id == 0 || id == null)
        {
            return View(obj);
        }
        else
        {
            obj.Book = await _db.Books.FirstOrDefaultAsync(tmp => tmp.Book_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Upsert(BookVM obj)
    {
        if (ModelState.IsValid)
        {
            if (obj?.Book != null)
            {
                if (obj.Book.Book_Id == 0)
                {
                    await _db.Books.AddAsync(obj.Book);
                }
                else
                {
                    _db.Books.Update(obj.Book);
                }
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }
        return View(obj);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        BookDetail obj = await _db.BookDetails.Include(tmp=>tmp.Book).FirstOrDefaultAsync(tmp => tmp.BookDetail_Id == id);

        //if (obj == null)
        //{
        //    obj = new();
        //    obj.Book = await _db.Books.FirstOrDefaultAsync(tmp => tmp.Book_Id == id);
        //}      
        return View(obj);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Details(BookDetail obj)
    {
        if (ModelState.IsValid)
        {
            if (obj != null)
            {
                // Ensure obj.Book is not null before accessing its properties
                obj.Book_Id = obj.Book?.Book_Id ?? 0;

                if (obj.BookDetail_Id == 0)
                {
                    await _db.BookDetails.AddAsync(obj);
                }
                else
                {
                    _db.BookDetails.Update(obj);
                }

                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }

        return View(obj);
    }


    public async Task<IActionResult> Delete(int? id)
    {
        Book book = _db.Books.FirstOrDefault(tmp => tmp.Book_Id == id);
        if (book == null)
        {
            return NotFound();
        }
        _db.Books.Remove(book);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    
    public IActionResult Playground(int id)
    {
        Book book = new Book
        {
            Book_Id = id,
            Title = "test",
            Publisher_Id = 1,
            Price = 1,
            ISBN = "555",
            PriceRange = "100-200"
        };
        _db.Books.Add(book);
        _db.SaveChanges();

        book.Title = "Edited to Test Attach";
        _db.Books.Attach(book);

        /*var bookTemp = await _db.Books.FirstOrDefaultAsync();
        if (bookTemp == null)
        {
            return NotFound();
        }
        bookTemp.Price = 100;

        var bookCollection = _db.Books;
        decimal totalPrice = 0;
        foreach (var book in bookCollection)
        {
            totalPrice += book.Price;
        }

        var bookList = await _db.Books.ToListAsync();
        foreach (var book in bookList)
        {
            totalPrice += book.Price;
        }
        var bookCollection2 = _db.Books;
        var bookCount1 = bookCollection2.Count();
        var bookCount2 = _db.Books.Count();*/
        return RedirectToAction(nameof(Index));
    }

}
