using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki.Model.Models
{
    public class FluentBookAuthorMap
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public FluentBook Book { get; set; }
        public FluentAuthor Author { get; set; }
    }
}
