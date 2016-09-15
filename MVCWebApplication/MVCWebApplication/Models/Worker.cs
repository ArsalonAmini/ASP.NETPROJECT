using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCWebApplication.Models
{
    public class Worker
    {

        [Key]

        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [ForeignKey("ApplicationUser")]

        public string ApplicationUserID { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        

    }
}