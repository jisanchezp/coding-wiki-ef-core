using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki.Model.Models
{
    public class Publisher
    {
        [Key]
        [Column("Id")]
        public int PublisherId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Location { get; set; }

        public List<Book> Books { get; set; }
    }
}
