using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _421FinalProject.Data;
using _421FinalProject.Models;

namespace _421FinalProject.Views
{
    public class GenInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GenInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GenInfoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GenInfo.Include(g => g.Destination);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GenInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genInfo = await _context.GenInfo
                .Include(g => g.Destination)
                .FirstOrDefaultAsync(m => m.GenInfoID == id);
            if (genInfo == null)
            {
                return NotFound();
            }

            return View(genInfo);
        }

        // GET: GenInfoes/Create
        public IActionResult Create()
        {
            ViewData["DestID"] = new SelectList(_context.Destination, "DestID", "City");
            return View();
        }

        // POST: GenInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GenInfoID,DestID,Title,subTitle,TextItem1,TextItem2,Image1,Image2")] GenInfo genInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DestID"] = new SelectList(_context.Destination, "DestID", "City", genInfo.DestID);
            return View(genInfo);
        }

        // GET: GenInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genInfo = await _context.GenInfo.FindAsync(id);
            if (genInfo == null)
            {
                return NotFound();
            }
            ViewData["DestID"] = new SelectList(_context.Destination, "DestID", "City", genInfo.DestID);
            return View(genInfo);
        }

        // POST: GenInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GenInfoID,DestID,Title,subTitle,TextItem1,TextItem2,Image1,Image2")] GenInfo genInfo)
        {
            if (id != genInfo.GenInfoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenInfoExists(genInfo.GenInfoID))
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
            ViewData["DestID"] = new SelectList(_context.Destination, "DestID", "City", genInfo.DestID);
            return View(genInfo);
        }

        // GET: GenInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genInfo = await _context.GenInfo
                .Include(g => g.Destination)
                .FirstOrDefaultAsync(m => m.GenInfoID == id);
            if (genInfo == null)
            {
                return NotFound();
            }

            return View(genInfo);
        }

        // POST: GenInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genInfo = await _context.GenInfo.FindAsync(id);
            _context.GenInfo.Remove(genInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenInfoExists(int id)
        {
            return _context.GenInfo.Any(e => e.GenInfoID == id);
        }
    }
}
