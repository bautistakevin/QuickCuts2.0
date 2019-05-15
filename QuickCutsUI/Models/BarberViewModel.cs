using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickCutsUI.Models
{
    public class BarberViewModel
    {
        public Barber Barber { get; set; }
        public List<Services> Services { get; set; }
        public List<Ratings> Ratings { get; set; }
        public List<Pictures> Pictures { get; set; }
    }
}
