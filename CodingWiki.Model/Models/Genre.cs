using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki.Model.Models
{
    [Table("tb_genres")]
    public class Genre
    {
        public int Id { get; set; }
        [Column("GenreName")]
        public string Name { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
    }
}
