using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuickCuts.Models
{
    public class Ratings
    {
        [Key]
        public int RatingId { get; set; }
        public string BarberId { get; set; }
        public string UserId { get; set; }
        public int RatingNumber { get; set; }
        public string Comment { get; set; }

        public virtual Barber Barber { get; set; }
    }
}
