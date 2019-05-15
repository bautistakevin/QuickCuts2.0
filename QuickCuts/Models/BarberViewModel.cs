using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuickCuts.Models
{
    public class BarberViewModel
    {
        [Key]
        public Barber Barber { get; set; }
        public List<Services> Services { get; set; }
        public List<Ratings> Ratings { get; set; }
        public List<Pictures> Pictures { get; set; }
    }
}
