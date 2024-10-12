using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki.Model.ViewModels
{
    public class BookVM
    {
        public BookVM Book { get; set; }
        public IEnumerable<SelectListItem> PublisherList { get; set; }
    }
}
