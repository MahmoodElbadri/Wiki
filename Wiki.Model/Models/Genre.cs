using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Model.Models;
[Table("Genres")]
public class Genre
{
    public int GenreId { get; set; }
    [Column("Name")]
    public string? GenreName { get; set; }
    public int DisplayOrder { get; set; }
}
