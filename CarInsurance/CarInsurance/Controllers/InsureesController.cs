using CarInsurance.Data;
using CarInsurance.Models;
using CarInsurance.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

namespace CarInsurance.Controllers
{
    public class InsureesController : Controller
    {
        private readonly CarInsuranceDbContext _context;

        public InsureesController(CarInsuranceDbContext context)
        {
            _context = context;
        }

        // GET: Insurees
        public async Task<IActionResult> Admin()
        {
            return View(await _context.Insurees.ToListAsync());
        }

        // GET: Insurees/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuree = await _context.Insurees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insuree == null)
            {
                return NotFound();
            }

            return View(insuree);
        }

        // GET: Insurees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Insurees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] ViewInsuree viewInsuree)
        {
            if (ModelState.IsValid)
            {
                var insuree = new Insuree
                {
                    FirstName = viewInsuree.FirstName,
                    LastName = viewInsuree.LastName,
                    EmailAddress = viewInsuree.EmailAddress,
                    DateOfBirth = viewInsuree.DateOfBirth,
                    CarYear = viewInsuree.CarYear,
                    CarMake = viewInsuree.CarMake,
                    CarModel = viewInsuree.CarModel,
                    DUI = viewInsuree.DUI,
                    SpeedingTickets = viewInsuree.SpeedingTickets,
                    CoverageType = viewInsuree.CoverageType,
                    Quote = viewInsuree.Quote,
                    Id = Guid.NewGuid()
                };

                _context.Add(insuree);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("Preview", viewInsuree);
        }

        [HttpPost]
        public IActionResult Preview([Bind("FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] ViewInsuree viewInsuree)
        {
            if (ModelState.IsValid)
            {
                // Calculating quote
                decimal baseQuote = 50;
                int age = DateTime.Now.Year - viewInsuree.DateOfBirth.Year; // Calculating age
                if (viewInsuree.DateOfBirth.Date > DateTime.Now.AddYears(-age)) { age--; } // Adjust for birth date not having occurred yet this year

                // Adjust qoute based on age
                if (age <= 18) { baseQuote += 100; }
                else if (age >= 19 && age <= 25) { baseQuote += 50; }
                else baseQuote += 25;

                // Adjust quote based on car's age
                if (viewInsuree.CarYear.Year < 2000) { baseQuote += 25; }
                else if (viewInsuree.CarYear.Year > 2015) { baseQuote += 25; }

                //Adjust quote based on car's make
                if (viewInsuree.CarMake == "Porsche")
                {
                    baseQuote += 25;
                    if (viewInsuree.CarModel == "911 Carrera") { baseQuote += 25; }
                }

                //Adjust quote based on speeding tickets
                baseQuote += viewInsuree.SpeedingTickets * 10;

                //Adjust quote based on DUI
                baseQuote += viewInsuree.DUI ? baseQuote * (decimal)0.25 : 0;

                //Adjust quote based on coverege type
                if (viewInsuree.CoverageType == "Full") { baseQuote += baseQuote * (decimal)0.5; }

                viewInsuree.Quote = baseQuote;

                // pass data to the confirmation view
                return View(viewInsuree);
            }
            return View("Create", viewInsuree);
        }

        // GET: Insurees/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuree = await _context.Insurees.FindAsync(id);
            if (insuree == null)
            {
                return NotFound();
            }
            return View(insuree);
        }

        // POST: Insurees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
        {
            if (id != insuree.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insuree);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsureeExists(insuree.Id))
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
            return View(insuree);
        }

        // GET: Insurees/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuree = await _context.Insurees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insuree == null)
            {
                return NotFound();
            }

            return View(insuree);
        }

        // POST: Insurees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var insuree = await _context.Insurees.FindAsync(id);
            if (insuree != null)
            {
                _context.Insurees.Remove(insuree);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsureeExists(Guid id)
        {
            return _context.Insurees.Any(e => e.Id == id);
        }
    }
}
