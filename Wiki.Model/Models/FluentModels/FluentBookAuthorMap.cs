using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Wiki.Model.Models;

[PrimaryKey(nameof(Book_Id), nameof(Author_Id))] // Composite key defined
public class FluentBookAuthorMap
{
    [ForeignKey(nameof(Book))]
    public int Book_Id { get; set; }

    [ForeignKey(nameof(Author))]
    public int Author_Id { get; set; }

    public FluentBook? Book { get; set; }
    public FluentAuthor? Author { get; set; }
}
