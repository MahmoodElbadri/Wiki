using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wiki.Model.Models;

namespace Wiki.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().Property(tmp => tmp.Price).HasPrecision(10, 5);
            modelBuilder.Entity<Book>().HasData(new Book()
            {
                Id = 1,
                Title = "Book 1",
                ISBN = "123456789",
                Price = 10.99M
            },
            new Book()
            {
                Id = 2,
                Title = "Book 2",
                ISBN = "123456789",
                Price = 10.99M
            },
            new Book()
            {
                Id = 3,
                Title = "Book 3",
                ISBN = "123456789",
                Price = 10.99M
            }
            );
            var GenreList = new List<Genre>()
            {
                new Genre() {
                    DisplayOrder = 1,
                    GenreId = 1,
                    GenreName = "Action"
            },
                new Genre() {
                    DisplayOrder = 2,
                    GenreId = 2,
                    GenreName = "Drama" }
            };
                modelBuilder.Entity<Genre>().HasData(GenreList);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CodingWiki;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
