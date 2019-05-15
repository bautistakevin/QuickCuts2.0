using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuickCuts.Models
{
    public class Zip
    {
        [Key]
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
