using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _421FinalProject.Models
{
    public class Place
    {
        [Key]
        public int PlaceID { get; set; }
        [Required]
        [ForeignKey("City")]
        public int Id { get; set; }
        public virtual City City { get; set; }

        [Required]
        public string Subset { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Description { get; set; }

        public string Note { get; set; }

        [DataType(DataType.Upload)]
        public byte[] ImageA { get; set; }

        [DataType(DataType.Upload)]
        public byte[] ImageB { get; set; }

        public string OfficialSite { get; set; }

        public string LocationKey { get; set; }

    }
}
