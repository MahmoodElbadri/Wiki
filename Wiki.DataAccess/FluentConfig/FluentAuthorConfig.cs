using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wiki.Model.Models;

namespace Wiki.DataAccess.FluentConfig;
public class FluentAuthorConfig : IEntityTypeConfiguration<FluentAuthor>
{
    public void Configure(EntityTypeBuilder<FluentAuthor> modelBuilder)
    {
        modelBuilder
            .HasKey(tmp => tmp.Author_Id);
        modelBuilder
            .Property(tmp => tmp.FirstName)
            .IsRequired();
        modelBuilder
            .Property(tmp => tmp.LastName)
            .IsRequired();
        modelBuilder
            .Ignore(tmp => tmp.FullName);
    }
}
