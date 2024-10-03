using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki.Model.Models
{
    public class FluentPublisher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Location { get; set; }

        //List<FluentBook> Books { get; set; }
    }
}
