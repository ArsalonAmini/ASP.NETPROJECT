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

        public int CreditCardNumber { get; set; }

        public int ExpirationDate { get; set; }

        public int SecurityCode { get; set; }

       

    }
}