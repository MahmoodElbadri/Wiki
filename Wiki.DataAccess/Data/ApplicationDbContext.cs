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
        public DbSet<BookDetail> BookDetails { get; set; }
        //fluent 
        public DbSet<FluentBookDetail> BookDetailsFluent { get; set; }
        public DbSet<FluentBook> FluentBooks { get; set; }
        public DbSet<FluentPublisher> FluentPublishers { get; set; }
        public DbSet<FluentAuthor> FluentAuthors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FluentBookDetail>()
                .ToTable("Fluent_BookDetail");
            modelBuilder.Entity<FluentBookDetail>()
                .Property(tmp => tmp.NumberOfChapters)
                .HasColumnName("NoOfChapters");
            modelBuilder.Entity<FluentBookDetail>()
                .Property(tmp => tmp.NumberOfChapters)
                .IsRequired();
            modelBuilder.Entity<FluentBookDetail>()
                .HasKey(tmp => tmp.BookDetail_Id);


            modelBuilder.Entity<FluentBook>()
                .ToTable("Fluent_Book");
            modelBuilder.Entity<FluentBook>()
                .Property(tmp => tmp.ISBN)
                .HasMaxLength(50);
            modelBuilder.Entity<FluentBook>()
                .Property(tmp => tmp.ISBN)
                .IsRequired();
            modelBuilder.Entity<FluentBook>()
                .HasKey(tmp => tmp.Book_Id);
            modelBuilder.Entity<FluentBook>()
                .Ignore(tmp => tmp.PriceRange);


            modelBuilder.Entity<FluentPublisher>()
                            .ToTable("Fluent_Publisher");
            modelBuilder.Entity<FluentPublisher>()
                .HasKey(tmp => tmp.Publisher_Id);
            modelBuilder.Entity<FluentPublisher>()
                .Property(tmp => tmp.Name)
                .IsRequired();


            modelBuilder.Entity<FluentAuthor>()
                .ToTable("Fluent_Author");
            modelBuilder.Entity<FluentAuthor>()
                .HasKey(tmp => tmp.Author_Id);
            modelBuilder.Entity<FluentAuthor>()
                .Property(tmp=>tmp.FirstName)
                .IsRequired();
            modelBuilder.Entity<FluentAuthor>()
                .Property (tmp=>tmp.LastName)
                .IsRequired();
            modelBuilder.Entity<FluentAuthor>()
                .Ignore(tmp => tmp.FullName);


            modelBuilder.Entity<Book>().Property(tmp => tmp.Price).HasPrecision(10, 5);
            var publisherList = new List<Publisher>()
            {
                new Publisher()
                {
                    Name = "AlAhram",
                    Location =  "Egypt",
                    Publisher_Id = 1
                },
                new Publisher()
                {
                    Name = "Penguin",
                    Location =  "USA",
                    Publisher_Id = 2
                },
                new Publisher()
                {
                    Name = "HarperCollins",
                    Location =  "USA",
                    Publisher_Id = 3
                },
                new Publisher()
                {
                    Name = "Hachette",
                    Location =  "France",
                    Publisher_Id = 4
                }
            };
            modelBuilder.Entity<Publisher>().HasData(publisherList);
            modelBuilder.Entity<Book>().HasData(new Book()
            {
                Book_Id = 1,
                Title = "Book 1",
                ISBN = "123456789",
                Price = 10.99M,
                Publisher_Id = 1
            },
            new Book()
            {
                Book_Id = 2,
                Title = "Book 2",
                ISBN = "123456789",
                Price = 10.99M,
                Publisher_Id = 2
            },
            new Book()
            {
                Book_Id = 3,
                Title = "Book 3",
                ISBN = "123456789",
                Price = 10.99M,
                Publisher_Id = 3
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
            modelBuilder.Entity<BookAuthorMap>().HasKey(tmp => new { tmp.Author_Id, tmp.Book_Id });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CodingWiki;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
