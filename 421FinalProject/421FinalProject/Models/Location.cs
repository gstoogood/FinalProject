using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _421FinalProject.Models
{
    public class Location
    {
        [Key]
        public int LocID { get; set; }

        [Required]
        [ForeignKey("Destination")]
        public int DestID { get; set; }

        [Required]
        public string Subset { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Description { get; set; }


        public string Note { get; set; }

        [Required]
        public string PriceRange { get; set; }

        [Required]
        public byte[] Image1 { get; set; }

        public byte[] Image2 { get; set; }

        public virtual Destination Destination { get; set; }

    }
}
