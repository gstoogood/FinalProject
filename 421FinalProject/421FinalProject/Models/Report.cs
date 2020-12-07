using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _421FinalProject.Models
{
    public class Report
    {
        [Key]
        public int ReportID { get; set; }
        public string ReportName { get; set; }
        public string CategoryOne { get; set; }
        public string CategoryTwo { get; set; }
        public int ValueOne { get; set; }
        public int ValueTwo { get; set; }

    }
}
