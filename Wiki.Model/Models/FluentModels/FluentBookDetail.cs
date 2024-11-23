using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Model.Models;
public class FluentBookDetail
{
    public int BookDetail_Id { get; set; }
    public int NumberOfChapters { get; set; }
    public int NumberOfPages { get; set; }
    public string? Weight { get; set; }
    //[ForeignKey(nameof(Book))]
    public int Book_Id { get; set; }
    public virtual FluentBook? Book { get; set; }

}
