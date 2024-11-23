using System.ComponentModel.DataAnnotations.Schema;
using Wiki.Model.Models;

public class BookAuthorMap
{
    [ForeignKey(nameof(Book))]
    public int Book_Id { get; set; }

    [ForeignKey(nameof(Author))]
    public int Author_Id { get; set; }

    public virtual Book? Book { get; set; } // Navigation property for Book
    public virtual Author? Author { get; set; } // Navigation property for Author
}
