using System;
using System.Collections.Generic;

namespace WebAPIDecor.Models
{
    public partial class Poster
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string ImgUrl { get; set; }
    }
}
