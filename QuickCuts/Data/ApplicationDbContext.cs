using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuickCuts.Models;

namespace QuickCuts.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public  DbSet<Barber> Barber { get; set; }
        public  DbSet<Favorites> Favorites { get; set; }
        public  DbSet<Pictures> Pictures { get; set; }
        public  DbSet<Ratings> Ratings { get; set; }
        public  DbSet<Services> Services { get; set; }
        public  DbSet<Zip> Zip { get; set; }
    }
}
