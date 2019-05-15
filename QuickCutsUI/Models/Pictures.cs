using System;
using System.Collections.Generic;

namespace QuickCutsUI.Models
{
    public partial class Pictures
    {
        public int PictureId { get; set; }
        public string OwnerId { get; set; }
        public string Category { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

        public virtual AspNetUsers Owner { get; set; }
    }
}
