using System;
using System.Collections.Generic;

namespace QuickCutsUI.Models
{
    public partial class Barber
    {
        public Barber()
        {
            Favorites = new HashSet<Favorites>();
            Ratings = new HashSet<Ratings>();
        }

        public string BarberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string BusinessHours { get; set; }
        public string PolicyInfo { get; set; }

        public virtual AspNetUsers BarberNavigation { get; set; }
        public virtual Services Services { get; set; }
        public virtual ICollection<Favorites> Favorites { get; set; }
        public virtual ICollection<Ratings> Ratings { get; set; }
    }
}
