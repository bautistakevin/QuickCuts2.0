using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuickCuts.Models
{
    public class Pictures
    {
        [Key]
        public int PictureId { get; set; }
        public string OwnerId { get; set; }
        public string Category { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

    }
}
