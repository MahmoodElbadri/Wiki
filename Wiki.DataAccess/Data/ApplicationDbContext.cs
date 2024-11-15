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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
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
            var GenreList = new List<Category>()
            {
                new Category() {
                    DisplayOrder = 1,
                    CategoryId = 1,
                    CategoryName = "Action"
            },
                new Category() {
                    DisplayOrder = 2,
                    CategoryId = 2,
                    CategoryName = "Drama"
                },
                new Category() {
                    DisplayOrder = 3,
                    CategoryId = 3,
                    CategoryName = "Comedy"
            }
            };
            modelBuilder.Entity<Category>().HasData(GenreList);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CodingWiki;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
