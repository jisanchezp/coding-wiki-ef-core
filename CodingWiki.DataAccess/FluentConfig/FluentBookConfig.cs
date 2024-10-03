using CodingWiki.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki.DataAccess.FluentConfig
{
    public class FluentBookConfig : IEntityTypeConfiguration<FluentBook>
    {
        public void Configure(EntityTypeBuilder<FluentBook> modelBuilder)
        {
            modelBuilder.HasKey(p => p.Book_Id);
            modelBuilder.Property(p => p.ISBN)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Ignore(p => p.PriceRange);
            modelBuilder.HasOne(p => p.Publisher).WithMany(p => p.Books)
                .HasForeignKey(p => p.PublisherId);
        }
    }
}
