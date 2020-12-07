using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _421FinalProject.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string OfficialLanguage { get; set; }

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
