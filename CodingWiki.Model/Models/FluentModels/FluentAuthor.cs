using CodingWiki.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki.Model.FluentModels
{
    public class FluentAuthor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime BirthDate { get; set; }
        public string Location { get; set; }
        [NotMapped]
        public string FullName { get {
                return $"{FirstName} {LastName}";
            }
        }

        //public List<FluentBookAuthorMap> BookAuthorMap { get; set; }
    }
}
