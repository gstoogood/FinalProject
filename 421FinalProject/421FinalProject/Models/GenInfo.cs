using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _421FinalProject.Models
{
    public class GenInfo
    {
        [Key]
        public int GenInfoID { get; set; }

        [Required]
        [ForeignKey("Destination")]
        public int DestID { get; set; }

        [Required]
        public string Title { get; set; }

        public string subTitle { get; set; }

        [Required]
        public string TextItem1 { get; set; }

        public string TextItem2 { get; set; }

        [Required]
        public byte[] Image1 { get; set; }

        public byte[] Image2 { get; set; }

        public virtual Destination Destination { get; set; }

    }
}
