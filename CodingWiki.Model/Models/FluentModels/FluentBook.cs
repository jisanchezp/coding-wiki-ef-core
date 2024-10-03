﻿using System;
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
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        [MaxLength(20)]
        [Required]
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        [NotMapped]
        public string PriceRange { get; set; }

        public FluentBookDetail BookDetail { get; set; }

        //[ForeignKey("Publisher")]
        //public int PublisherId { get; set; }
        //public FluentPublisher Publisher { get; set; }
        //public List<FluentBookAuthorMap> BookAuthorMap { get; set; }
    }
}