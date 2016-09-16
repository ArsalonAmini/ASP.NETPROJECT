using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCWebApplication.Models
{
    public class Payment
    {
        [Key]

        public int id { get; set; }

        [Required]
        public int CreditCardNumber { get; set; }

        [Display(Name = "ExpirationDate")]
        public int ExpirationDate { get; set; }

        public int SecurityCode { get; set; }

       

    }
}