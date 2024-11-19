using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Wiki.Model.Models;

namespace Wiki.DataAccess.Data;

public class FluentPublisher
{
    public int Publisher_Id { get; set; }
    public string? Name { get; set; }

    public string? Location { get; set; }
    //public List<FluentBook>? Books { get; set; }
}
