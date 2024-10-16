using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki.Model.Models
{
    public class BookDetail
    {
        [Key]
        [Column("Id")]
        public int BookDetailId { get; set; }
        [Required]
        public int NumberOfChapters { get; set; }
        public int NumberOfPages { get; set; }
        public double Weight { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
