using System;
using System.Collections.Generic;

namespace QuickCutsUI.Models
{
    public partial class Ratings
    {
        public int RatingId { get; set; }
        public string BarberId { get; set; }
        public string UserId { get; set; }
        public int RatingNumber { get; set; }
        public string Comment { get; set; }

        public virtual Barber Barber { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
