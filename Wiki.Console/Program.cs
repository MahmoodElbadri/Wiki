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
        AddBook();
        GetBooks();
    }
    public static void GetBooks()
    {
        using var db = new ApplicationDbContext();

        var books = db.Books.ToList();
        foreach (var book in books)
        {
          System. Console.WriteLine(book.Title + " " + book.ISBN);
        }
    }

    public static void AddBook()
    {
        using var db = new ApplicationDbContext();
        Book book = new Book()
        {
            ISBN = "6789",
            Title = "Guliver's Travels",
            Price = 100,
            Publisher_Id = 2
        };
        db.Books.Add(book);
        db.SaveChanges();
    }
}
