using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject421.Models
{
    public class Destination
    {
        [Key]
        public int DestID { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string OfficialLanguage { get; set; }

        [Required]
        public byte[] Image1 { get; set; }

        public byte[] Image2 { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        public byte[] ImageA { get; set; }

        [DataType(DataType.Upload)]
        public byte[] ImageB { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageC { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageD { get; set; }

        public string OfficialSite { get; set; }

        public string LocationKey { get; set; }
    }
}
