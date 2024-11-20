using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Model.Models;
[Table("Categories")]
public class Category
{
    public int CategoryId { get; set; }
    [Column("Name")]
    public string? CategoryName { get; set; }
}
