using System;
using System.Collections.Generic;

namespace WebAPIDecor.Models
{
    public partial class WallpaperJournal
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Describtion { get; set; }
        public string Brand { get; set; }
        public string Year { get; set; }
        public string ImgUrl { get; set; }
    }
}
