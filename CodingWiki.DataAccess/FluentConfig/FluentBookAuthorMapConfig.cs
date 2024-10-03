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
    public class FluentBookAuthorMapConfig : IEntityTypeConfiguration<FluentBookAuthorMap>
    {
        public void Configure(EntityTypeBuilder<FluentBookAuthorMap> modelBuilder)
        {
            modelBuilder.HasKey(m => new { m.BookId, m.AuthorId });
            modelBuilder.HasOne(m => m.Book).WithMany(m => m.BookAuthorMap)
                .HasForeignKey(p => p.BookId);
            modelBuilder.HasOne(m => m.Author).WithMany(m => m.BookAuthorMap)
                .HasForeignKey(p => p.AuthorId);
        }
    }
}
