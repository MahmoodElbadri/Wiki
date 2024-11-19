using System.ComponentModel.DataAnnotations.Schema;
using Wiki.Model.Models;

public class BookAuthorMap
{
    [ForeignKey(nameof(Book))]
    public int Book_Id { get; set; }

    [ForeignKey(nameof(Author))]
    public int Author_Id { get; set; }

    public Book? Book { get; set; } // Navigation property for Book
    public Author? Author { get; set; } // Navigation property for Author
}
