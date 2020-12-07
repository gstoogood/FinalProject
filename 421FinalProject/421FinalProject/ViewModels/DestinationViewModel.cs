using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _421FinalProject.Models;

namespace _421FinalProject.ViewModels
{
    public class DestinationViewModel
    {
        public Destination Destination { get; set; }
        public List<Location> Locations { get; set; }
        public List<GenInfo> GenInfo { get; set; }

    }
}
