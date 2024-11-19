using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wiki.Model.Models;

namespace Wiki.DataAccess.FluentConfig;

public class FluentBookAuthorConfig : IEntityTypeConfiguration<BookAuthorMap>
{
    public void Configure(EntityTypeBuilder<BookAuthorMap> modelBuilder)
    {
        modelBuilder
                .HasKey(map => new { map.Book_Id, map.Author_Id });
        modelBuilder
            .HasOne(tmp => tmp.Book)
            .WithMany(tmp => tmp.BookAuthorMap)
            .HasForeignKey(tmp => tmp.Book_Id);
        modelBuilder
            .HasOne(tmp => tmp.Author)
            .WithMany(tmp => tmp.BookAuthorMap)
            .HasForeignKey(tmp => tmp.Author_Id);
    }
}
