using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wiki.DataAccess.Data;
using Wiki.Model.Models;

namespace Wiki.DataAccess.FluentConfig;
public class FluentPublisherConfig : IEntityTypeConfiguration<FluentPublisher>
{
    public void Configure(EntityTypeBuilder<FluentPublisher> modelBuilder)
    {
        modelBuilder
            .ToTable("Fluent_Publisher");
        modelBuilder
            .HasKey(tmp => tmp.Publisher_Id);
        modelBuilder
            .Property(tmp => tmp.Name)
            .IsRequired();
    }
}
