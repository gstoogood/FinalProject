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
    public class CitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cities
        public async Task<IActionResult> Index()
        {
            return View(await _context.City.ToListAsync());
        }

        // GET: Cities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.City
                .FirstOrDefaultAsync(m => m.Id == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // GET: Cities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Country,OfficialLanguage,OfficialSite,LocationKey")] City city, IFormFile ImageA, IFormFile ImageB, IFormFile ImageC, IFormFile ImageD)
        {
            if (ModelState.IsValid)
            {
                if (ImageA != null && ImageA.Length > 0)
                {
                    var memoryStream = new MemoryStream();
                    await ImageA.CopyToAsync(memoryStream);
                    city.ImageA = memoryStream.ToArray();
                }
                if (ImageB != null && ImageB.Length > 0)
                {
                    var memoryStream = new MemoryStream();
                    await ImageB.CopyToAsync(memoryStream);
                    city.ImageB = memoryStream.ToArray();
                }
                _context.Add(city);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        // GET: Cities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.City.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Country,OfficialLanguage,OfficialSite,LocationKey")] City city, IFormFile ImageA, IFormFile ImageB, IFormFile ImageC, IFormFile ImageD)
        {
            if (id != city.Id)
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
                        city.ImageA = memoryStream.ToArray();
                    }
                    else
                    {
                        City existingPlace = _context.City.AsNoTracking().FirstOrDefault(m => m.Id == id);
                        if (existingPlace != null)
                        {
                            city.ImageA = existingPlace.ImageA;
                        }
                    }
                    if (ImageB != null && ImageB.Length > 0)
                    {
                        var memoryStream = new MemoryStream();
                        await ImageB.CopyToAsync(memoryStream);
                        city.ImageB = memoryStream.ToArray();
                    }
                    else
                    {
                        City existingPlace = _context.City.AsNoTracking().FirstOrDefault(m => m.Id == id);
                        if (existingPlace != null)
                        {
                            city.ImageB = existingPlace.ImageB;
                        }
                    }
                    _context.Update(city);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityExists(city.Id))
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
            return View(city);
        }

        // GET: Cities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.City
                .FirstOrDefaultAsync(m => m.Id == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var city = await _context.City.FindAsync(id);
            _context.City.Remove(city);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CityExists(int id)
        {
            return _context.City.Any(e => e.Id == id);
        }
    }
}
