using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel;
namespace QuickCuts.Models
{
    public class UserViewModel
    {
        
        public List<Ratings> Ratings { get; set; }
        public List<Barber> Favorites { get; set; }
        public Pictures Pictures { get; set; }
    }
}
