using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuickCuts.Models
{
    public class Services
    {
        [Key]
        public int ServiceId { get; set; }
        public string BarberId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }

    }
}
