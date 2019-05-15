using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuickCuts.Data;
using QuickCuts.Models;

namespace QuickCuts.Controllers
{
    public class BarbersController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public BarbersController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        // GET: Barbers
        public async Task<IActionResult> Index()
        {
            return View(await dbContext.Barber.ToListAsync());
        }

        // GET: Barbers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barber = await dbContext.Barber
                .FirstOrDefaultAsync(m => m.BarberId == id);
            if (barber == null)
            {
                return NotFound();
            }

            return View(barber);
        }

        // GET: Barbers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Barbers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BarberId,FirstName,LastName,Address,Zip,PhoneNumber,BusinessHours,PolicyInfo")] Barber barber)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(barber);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(barber);
        }

        // GET: Barbers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barber = await dbContext.Barber.FindAsync(id);
            if (barber == null)
            {
                return NotFound();
            }
            return View(barber);
        }

        // POST: Barbers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("BarberId,FirstName,LastName,Address,Zip,PhoneNumber,BusinessHours,PolicyInfo")] Barber barber)
        {
            if (id != barber.BarberId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dbContext.Update(barber);
                    await dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BarberExists(barber.BarberId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(barber);
        }

        // GET: Barbers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barber = await dbContext.Barber
                .FirstOrDefaultAsync(m => m.BarberId == id);
            if (barber == null)
            {
                return NotFound();
            }

            return View(barber);
        }

        // POST: Barbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var barber = await dbContext.Barber.FindAsync(id);
            dbContext.Barber.Remove(barber);
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BarberExists(string id)
        {
            return dbContext.Barber.Any(e => e.BarberId == id);
        }
    }
}
