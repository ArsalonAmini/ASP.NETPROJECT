using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCWebApplication.Models
{
    public class Address
    {
        [Key]

        public int id { get; set; }

        [Required]
        [Display(Name = "Street")]
        public string Street { get; set; }

        [ForeignKey("City")]
        public int CityID { get; set; }

        public City City { get; set; }


        [ForeignKey("State")]
        public int StateID { get; set; }

        public State State { get; set; }

        [ForeignKey("Country")]
        public int CountryID { get; set; }

        public Country Country { get; set; }
    }
}
