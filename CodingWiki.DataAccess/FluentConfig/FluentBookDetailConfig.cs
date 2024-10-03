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
    public class FluentBookDetailConfig : IEntityTypeConfiguration<FluentBookDetail>
    {
        public void Configure(EntityTypeBuilder<FluentBookDetail> modelBuilder)
        {
            // Table name
            modelBuilder.ToTable("FluentBookDetails");

            // Column names
            modelBuilder.Property(p => p.NumberOfChapters).HasColumnName("NoOfChapters");

            // Primary key
            modelBuilder.HasKey(p => p.BookDetail_Id);

            // Other validations
            modelBuilder.Property(p => p.NumberOfChapters).IsRequired();

            // Relationships
            modelBuilder.HasOne(p => p.Book).WithOne(p => p.BookDetail)
                .HasForeignKey<FluentBookDetail>(p => p.BookId);
        }
    }
}
