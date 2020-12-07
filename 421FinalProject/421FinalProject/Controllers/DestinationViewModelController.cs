using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using _421FinalProject.Data;
using _421FinalProject.Models;
using _421FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _421FinalProject.Controllers
{
    public class DestinationVMController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DestinationVMController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> DestDetails(int? DestID)
        {
            if (DestID == null)
            {
                return NotFound();
            }
            else
            {
                
                var destination = await _context.Destination.FirstOrDefaultAsync(m => m.DestID == DestID);
                //List<Location> allLocations = await _context.Location.ForEachAsync(m => m.DestID == DestID);

                List<Location> destLocations = new List<Location>();
                var locationList = from Location in _context.Location where DestID == destination.DestID select Location;
                foreach (Location location in locationList)
                {
                    destLocations.Add(location);
                }
                List<GenInfo> destGenInfo = new List<GenInfo>();
                var genInfoList = from GenInfo in _context.GenInfo where DestID == destination.DestID select GenInfo;
                foreach (GenInfo genInfo in genInfoList)
                {
                    destGenInfo.Add(genInfo);
                }

                DestinationViewModel destVM = new DestinationViewModel();
                destVM.Destination = destination;
                destVM.Locations = destLocations;
                destVM.GenInfo = destGenInfo;

                return View(destVM);
            }
        }
    }
}
