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
    public class FluentAuthorConfig : IEntityTypeConfiguration<FluentAuthor>
    {
        public void Configure(EntityTypeBuilder<FluentAuthor> modelBuilder)
        {
            modelBuilder.HasKey(p => p.Author_Id);
            modelBuilder.Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Property(p => p.LastName).IsRequired();
            modelBuilder.Property(p => p.BirthDate).HasColumnType("datetime2");
            modelBuilder.Ignore(p => p.FullName);
        }
    }
}
