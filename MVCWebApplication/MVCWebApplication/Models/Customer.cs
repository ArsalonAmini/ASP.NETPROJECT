using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCWebApplication.Models
{
    public class Customer
    {
        [Key]

        
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        public int DOB { get; set; }

        [ForeignKey("Address")]

        public int AddressID { get; set; }

        [Required]
        public Address Address  { get; set; }
    }
}