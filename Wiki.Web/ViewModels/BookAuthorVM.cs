using Microsoft.AspNetCore.Mvc.Rendering;
using Wiki.Model.Models;

namespace Wiki.Web.ViewModels;

public class BookAuthorVM
{
    public BookAuthorMap BookAuthor { get; set; }
    public Book Book { get; set; }
    public IEnumerable<BookAuthorMap> BookAuthorList { get; set; }
    public IEnumerable<SelectListItem> AuthorList { get; set; }
}
