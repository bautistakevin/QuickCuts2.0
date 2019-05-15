using System;
using System.Collections.Generic;

namespace QuickCutsUI.Models
{
    public partial class Services
    {
        public string BarberId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }

        public virtual Barber Barber { get; set; }
    }
}
