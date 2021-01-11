using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIDecor.Models
{
    public class JournalswithCategoryTitle
    {
        public int Id { get; set; }
        public string CategoryTitle { get; set; }
        public string Title { get; set; }
        public string Describtion { get; set; }
        public string Brand { get; set; }
        public string Year { get; set; }
        public string ImgUrl { get; set; }
    }
}
