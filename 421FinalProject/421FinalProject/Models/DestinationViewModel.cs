using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject421.Models;

namespace FinalProject421.ViewModels
{
    public class DestinationViewModel2
    {
        public Destination Destination { get; set; }
        public List<Location> Locations { get; set; }
        public List<GenInfo> GenInfo { get; set; }

    }
}
