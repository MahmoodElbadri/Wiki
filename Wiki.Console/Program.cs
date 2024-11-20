using System;
using Microsoft.EntityFrameworkCore;
using Wiki.DataAccess.Data;
using Wiki.Model.Models;

namespace Wiki.Console;
public class Program
{
    static void Main(string[] args)
    {
        /*System.Console.WriteLine("Hello, World!");
        using (ApplicationDbContext db = new ApplicationDbContext())
        {
            db.Database.EnsureCreated();
            if (db.Database.GetPendingMigrations().Count() > 0)
            {
                db.Database.Migrate();
            }
        }*/
        //AddBook();
        //GetBook();
        //GetBookUsingWhereClause();
        //GetBookUsingFindClause();
        //UpdateBook();
        //DeleteBook();
        //GetBooks();
    }

    /*private static async void DeleteBook()
    {
        using var db = new ApplicationDbContext();
        Book? book = await db.Books.Where(tmp => tmp.Title == "Guliver's Travels").FirstOrDefaultAsync();
        db.Books.Remove(book!);
        await db.SaveChangesAsync();
    }

    private static async void UpdateBook()
    {
        using var db = new ApplicationDbContext();
        Book? book = await db.Books.Where(tmp => tmp.Title == "Guliver's Travels").FirstOrDefaultAsync();
        book!.Title = "Journey to the Center of the Earth";
        db.SaveChangesAsync();
    }

    private static async void GetBookUsingFindClause()
    {
        using var db = new ApplicationDbContext();
        Book? book = await db.Books.FindAsync(8);
        System.Console.WriteLine(book!.Title + " " + book.ISBN);
    }

    private static async void GetBookUsingWhereClause()
    {
        using var db = new ApplicationDbContext();
        var book = await db.Books.Where(tmp => tmp.Publisher_Id == 2).OrderBy(tmp => tmp.Title).ThenBy(tmp => tmp.Publisher_Id).ToListAsync();
        foreach (var item in book)
        {
            System.Console.WriteLine(item!.Title + " " + item.ISBN);
        }
    }

    private static async void GetBook()
    {
        using var db = new ApplicationDbContext();
        try
        {
            var book = await db.Books.FirstAsync();
            System.Console.WriteLine(book);
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
        }
    }

    public static async void GetBooks()
    {
        using var db = new ApplicationDbContext();

        var books =await db.Books.ToListAsync();
        foreach (var book in books)
        {
            System.Console.WriteLine(book.Title + " " + book.ISBN);
        }
    }

    public static async void AddBook()
    {
        using var db = new ApplicationDbContext();
        Book book = new Book()
        {
            ISBN = "6789",
            Title = "Gulliver's Travels",
            Price = 100,
            Publisher_Id = 2
        };
        db.Books.Add(book);
       await db.SaveChangesAsync();
    }*/
}
