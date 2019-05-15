using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuickCuts.Data;
using QuickCuts.Models;

namespace QuickCuts.Controllers
{
    public class PicturesController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public PicturesController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        // GET: Pictures
        public async Task<IActionResult> Index()
        {
            return View(await dbContext.Pictures.ToListAsync());
        }

        public IActionResult UploadPicture()
        {
            return View();
        }

        public IActionResult SavePicture(string imageName, IFormFile picture)
        {
            //user information
           // var LoggedInUser = dbContext.Users.Where(u => string.Equals(u.Email, User.Identity.Name)).FirstOrDefault();

            string fileName = picture.FileName;
            Pictures newPicture = new Pictures();
           // newPicture.OwnerId = LoggedInUser?.Id;
            newPicture.Category = "ProfilePicture";
            newPicture.ImageData = new byte[picture.Length];
            picture.OpenReadStream().Read(newPicture.ImageData);
            dbContext.Pictures.Add(newPicture);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard", "Home");

        }

        public FileContentResult GetImage(string Id)
        {
            Pictures picture = dbContext.Pictures.FirstOrDefault(i => i.OwnerId.Equals(Id));
            if( picture != null)
            {
                return File(picture.ImageData, picture.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        //TODO: differentiate between barber's profile picture and portfolio pictures
    }
}

