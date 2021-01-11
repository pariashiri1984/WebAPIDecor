using System;
using System.Collections.Generic;

namespace WebAPIDecor.Models
{
    public partial class WallpeparJournalItem
    {
        public int Id { get; set; }
        public int WallpaperJournalId { get; set; }
        public string ImgUrl { get; set; }
    }
}
