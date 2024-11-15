using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Wiki.Model.Models;

namespace Wiki.DataAccess.Data;

[Table("Publishers")]
public class Publisher
{
    [Key]
    public int Publisher_Id { get; set; }

    [Required]
    public string? Name { get; set; }

    public string? Location { get; set; }
    public List<Book>? Books { get; set; }
}
