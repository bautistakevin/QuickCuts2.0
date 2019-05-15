using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using QuickCuts.Data;
using QuickCuts.Models;
using Microsoft.EntityFrameworkCore;

namespace QuickCuts.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public HomeController(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            //user information
            var LoggedInUser = dbContext.Users.Where(u => string.Equals(u.Email, User.Identity.Name)).FirstOrDefault();
            ViewBag.name = User.Identity?.Name;
            ViewBag.id = LoggedInUser?.Id;

            if(LoggedInUser != null)
            {
                HttpContext.Session.SetString("userid", LoggedInUser.Id);
            }

            //populate the barber cards
            List<BarberViewModel> bvm = new List<BarberViewModel>();
            List<Barber> barbers = dbContext.Barber.FromSql($"SELECT * FROM Barber WHERE BarberId IS NOT NULL").ToList();
            foreach(Barber barber in barbers)
            {
                BarberViewModel temp = new BarberViewModel();
                temp.Services = dbContext.Services.Where(s => s.BarberId.Equals(barber.BarberId)).ToList();
                temp.Barber = barber;
                bvm.Add(temp);
            }
            ViewBag.BarberViewModel = bvm;
            return View();
        }

        public IActionResult Dashboard()
        {
            //logged in user information
            var LoggedInUser = dbContext.Users.Where(u => string.Equals(u.Email, User.Identity.Name)).FirstOrDefault();
            ViewBag.name = User.Identity?.Name;
            ViewBag.id = LoggedInUser?.Id;

            ////////////////////////////////
            //building the user view model//
            ////////////////////////////////
            
            //build the Favorites
            List<Favorites> Favorites = new List<Favorites>();
            Favorites = dbContext.Favorites.Where(f => f.UserId.Equals(LoggedInUser.Id)).ToList();
            List<Barber> FavoriteBarbers = new List<Barber>();
            foreach (Favorites favs in Favorites)
            {
                FavoriteBarbers.Add(dbContext.Barber.Where(b => b.BarberId.Equals(favs.BarberId)).FirstOrDefault());
            }
            //build the Ratings
            List<Ratings> Ratings = new List<Ratings>();
            Ratings = dbContext.Ratings.Where(r => r.UserId.Equals(LoggedInUser.Id)).ToList();
            
            //build the pictures
            Pictures Pictures = new Pictures();
            //Pictures = dbContext.Pictures.Where(p => p.OwnerId.Equals(LoggedInUser.Id)).First();

            //scaffold the UserViewModel
            UserViewModel uvm = new UserViewModel();
            uvm.Ratings= Ratings;

            //populate the barber cards using FavoriteBarbers
            List<BarberViewModel> bvm = new List<BarberViewModel>();
            foreach(Barber barber in FavoriteBarbers)
            {
                BarberViewModel temp = new BarberViewModel();
                temp.Services = dbContext.Services.Where(s => s.BarberId.Equals(barber.BarberId)).ToList();
                temp.Barber = barber;
                bvm.Add(temp);
            }
            ViewBag.BarberViewModel = bvm;

            return View(uvm);
        }

        public IActionResult Profile(string Id)
        {
            //create the BarberViewModel
            BarberViewModel bvm = new BarberViewModel();
            Barber barbers = dbContext.Barber.Where(b => b.BarberId.Equals(Id)).First();
            bvm.Barber = barbers;
            bvm.Services = dbContext.Services.Where(s => s.BarberId.Equals(Id)).ToList();
            bvm.Ratings = dbContext.Ratings.Where(r => r.Barber.Equals(Id)).ToList();

            
            return View(bvm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
