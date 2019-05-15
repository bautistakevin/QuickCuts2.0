using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickCutsUI.Models
{
    public class UserViewModel
    {
        public AspNetUsers AspNetUsers { get; set; }
        public List<Ratings> Ratings { get; set; }
        public List<Favorites> Favorites { get; set; }
        public Pictures Pictures { get; set; }
    }
}
