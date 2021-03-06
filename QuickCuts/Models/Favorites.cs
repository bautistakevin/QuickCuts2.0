﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuickCuts.Models
{
    public class Favorites
    {
        [Key]
        public int FavoritesId { get; set; }
        public string UserId { get; set; }
        public string BarberId { get; set; }

        public virtual Barber Barber { get; set; }
    }
}
