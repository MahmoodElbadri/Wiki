using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wiki.Model.Models;

namespace Wiki.DataAccess.FluentConfig;
public class FluentBookConfig : IEntityTypeConfiguration<FluentBook>
{
    public void Configure(EntityTypeBuilder<FluentBook> modelBuilder)
    {
        modelBuilder        
                .ToTable("Fluent_Book");
        modelBuilder
            .Property(tmp => tmp.ISBN)
            .HasMaxLength(50);
        modelBuilder
            .Property(tmp => tmp.ISBN)
            .IsRequired();
        modelBuilder
            .HasKey(tmp => tmp.Book_Id);
        modelBuilder
            .Ignore(tmp => tmp.PriceRange);
        modelBuilder
            .HasOne(tmp => tmp.Publisher)
            .WithMany(tmp => tmp.Books)
            .HasForeignKey(tmp => tmp.Publisher_Id);
    }
}
