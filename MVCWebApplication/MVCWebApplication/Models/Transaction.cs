using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCWebApplication.Models
{
    public class Transaction
    {
        [Key]

        public int id { get; set; }

        public int date { get; set; }

        [ForeignKey("Payment")]

        public int paymentId { get; set; }

        public Payment Payment { get; set; }



    }
}