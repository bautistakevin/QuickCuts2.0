using System;
using System.Collections.Generic;

namespace QuickCutsUI.Models
{
    public partial class Favorites
    {
        public string UserId { get; set; }
        public string BarberId { get; set; }

        public virtual Barber Barber { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
