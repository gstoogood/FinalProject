using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _421FinalProject.Data;
using _421FinalProject.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace _421FinalProject.Views
{
    public class PlacesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlacesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Places
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Place.Include(p => p.City);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Places/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var place = await _context.Place
                .Include(p => p.City)
                .FirstOrDefaultAsync(m => m.PlaceID == id);
            if (place == null)
            {
                return NotFound();
            }

            return View(place);
        }

        // GET: Places/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.City, "Id", "Country");
            return View();
        }

        // POST: Places/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlaceID,Id,Subset,Name,Address,Description,Note,OfficialSite,LocationKey")] Place place, IFormFile ImageA, IFormFile ImageB)
        {
            if (ModelState.IsValid)
            {
                if (ImageA != null && ImageA.Length > 0)
                {
                    var memoryStream = new MemoryStream();
                    await ImageA.CopyToAsync(memoryStream);
                    place.ImageA = memoryStream.ToArray();
                }
                if (ImageB != null && ImageB.Length > 0)
                {
                    var memoryStream = new MemoryStream();
                    await ImageA.CopyToAsync(memoryStream);
                    place.ImageA = memoryStream.ToArray();
                }
                _context.Add(place);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.City, "Id", "Country", place.Id);
            return View(place);
        }

        // GET: Places/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var place = await _context.Place.FindAsync(id);
            if (place == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.City, "Id", "Country", place.Id);
            return View(place);
        }

        // POST: Places/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlaceID,Id,Subset,Name,Address,Description,Note,OfficialSite,LocationKey")] Place place, IFormFile ImageA, IFormFile ImageB)
        {
            if (id != place.PlaceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (ImageA != null && ImageA.Length > 0)
                    {
                        var memoryStream = new MemoryStream();
                        await ImageA.CopyToAsync(memoryStream);
                        place.ImageA = memoryStream.ToArray();
                    }
                    else
                    {
                        City existingPlace = _context.City.AsNoTracking().FirstOrDefault(m => m.Id == id);
                        if (existingPlace != null)
                        {
                            place.ImageA = existingPlace.ImageA;
                        }
                    }
                    if (ImageB != null && ImageB.Length > 0)
                    {
                        var memoryStream = new MemoryStream();
                        await ImageB.CopyToAsync(memoryStream);
                        place.ImageB = memoryStream.ToArray();
                    }
                    else
                    {
                        City existingPlace = _context.City.AsNoTracking().FirstOrDefault(m => m.Id == id);
                        if (existingPlace != null)
                        {
                            place.ImageB = existingPlace.ImageB;
                        }
                    }
                    _context.Update(place);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaceExists(place.PlaceID))
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
            ViewData["Id"] = new SelectList(_context.City, "Id", "Country", place.Id);
            return View(place);
        }

        // GET: Places/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var place = await _context.Place
                .Include(p => p.City)
                .FirstOrDefaultAsync(m => m.PlaceID == id);
            if (place == null)
            {
                return NotFound();
            }

            return View(place);
        }

        // POST: Places/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var place = await _context.Place.FindAsync(id);
            _context.Place.Remove(place);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaceExists(int id)
        {
            return _context.Place.Any(e => e.PlaceID == id);
        }
    }
}
