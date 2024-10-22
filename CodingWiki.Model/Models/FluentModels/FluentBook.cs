using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki.Model.Models
{
    public class FluentBook
    {
        public int Book_Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public string PriceRange { get; set; }

        public virtual FluentBookDetail BookDetail { get; set; }
        public int PublisherId { get; set; }
        public virtual FluentPublisher Publisher { get; set; }
        //public List<FluentAuthor> Authors { get; set; }
        public virtual List<FluentBookAuthorMap> BookAuthorMap { get; set; }
    }
}
