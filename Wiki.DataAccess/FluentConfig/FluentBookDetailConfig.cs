using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wiki.Model.Models;

namespace Wiki.DataAccess.FluentConfig;
public class FluentBookDetailConfig : IEntityTypeConfiguration<FluentBookDetail>
{
    public void Configure(EntityTypeBuilder<FluentBookDetail> modelBuilder)
    {
        modelBuilder
            .ToTable("Fluent_BookDetail");
        modelBuilder
            .Property(tmp => tmp.NumberOfChapters)
            .HasColumnName("NoOfChapters");
        modelBuilder
            .Property(tmp => tmp.NumberOfChapters)
            .IsRequired();
        modelBuilder
            .HasKey(tmp => tmp.BookDetail_Id);
        modelBuilder
            .HasOne(tmp => tmp.Book)
            .WithOne(tmp => tmp.FluentBookDetail)
            .HasForeignKey<FluentBookDetail>(tmp => tmp.Book_Id);
    }
}
