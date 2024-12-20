﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.DataAccess.Data;

namespace Wiki.Model.Models;
public class Book
{
    [Key]
    public int Book_Id { get; set; }
    public string? Title { get; set; }
    [MaxLength(20)]
    [Required]
    public string? ISBN { get; set; }
    public decimal Price { get; set; }
    [NotMapped]
    public string? PriceRange { get; set; }
    public virtual BookDetail? BookDetail { get; set; }
    [ForeignKey(nameof(Publisher))]
    public int Publisher_Id { get; set; }
    public virtual Publisher? Publisher { get; set; }
    public virtual List<BookAuthorMap>? BookAuthorMap { get; set; }
}
