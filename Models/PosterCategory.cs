using System;
using System.Collections.Generic;

namespace WebAPIDecor.Models
{
    public partial class PosterCategory
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Describtion { get; set; }
        public string ImgUrl { get; set; }
    }
}
