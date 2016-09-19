using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCWebApplication.Models
{
    public class Schedule
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "StartDate")]
        public int StartDate { get; set; }

        [Required]
        [Display(Name = "SkipDate")]
        public int SkipDate { get; set; }
    }
}