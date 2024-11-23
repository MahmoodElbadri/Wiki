using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.DataAccess.Data;

namespace Wiki.Model.Models;
public class FluentBook
{
    public int Book_Id { get; set; }
    public string? Title { get; set; }
    public string? ISBN { get; set; }
    public decimal Price { get; set; }
    public string? PriceRange { get; set; }
    public FluentBookDetail? FluentBookDetail { get; set; }
    //[ForeignKey(nameof(Publisher))]
    public int Publisher_Id { get; set; }
    public virtual FluentPublisher? Publisher { get; set; }
    //public List<FluentAuthor>? FluentAuthors { get; set; } = new List<FluentAuthor>(); // <FluentAuthor>
    public virtual List<FluentBookAuthorMap>? BookAuthorMap { get; set; }
}
