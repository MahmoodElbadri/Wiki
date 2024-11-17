using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Model.Models;
public class FluentBookAuthorMap
{
    [Key]
    [ForeignKey(nameof(Book))]
    public int Book_Id { get; set; }
    [Key]
    [ForeignKey(nameof(Author))]
    public int Author_Id { get; set; }
    //public FluentBook? Book { get; set; }
    //public FluentAuthor? Author { get; set; }
}
