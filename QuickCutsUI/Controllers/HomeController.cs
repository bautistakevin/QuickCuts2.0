using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuickCutsUI.Models;

namespace QuickCutsUI.Controllers
{
    public class HomeController : Controller
    {
        private QuickCutsContext QuickCutsContext;

        public HomeController(QuickCutsContext quickCutsContext)
        {
            QuickCutsContext = quickCutsContext;
        }

        public IActionResult Index()
        {
            //var loggedInUser = QuickCutsContext.AspNetUsers.Where(u => string.Equals(u.Email, User.Identity.Name)).FirstOrDefault();
            //ViewBag.name = User.Identity?.Name;
            //ViewBag.id = loggedInUser?.Id;
            //List<BarberViewModel> bvm = new List<BarberViewModel>();
            //List<Barber> barbersList = QuickCutsContext.Barber.FromSql($"SELECT * FROM Barber WHERE BarberId IS NOT NULL").ToList();
            //foreach(Barber barber in barbersList)
            //{
            //    BarberViewModel temp = new BarberViewModel();
            //    temp.Services = QuickCutsContext.Services.Where(s => s.BarberId.Equals(barber.BarberId)).ToList();
            //    temp.Barber = barber;
            //    bvm.Add(temp);
            //}
            //ViewBag.BarberViewModel = bvm;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
