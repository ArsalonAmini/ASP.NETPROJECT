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

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        [ForeignKey("Schedule")]
        public int ScheduleId { get; set; }

        public Schedule Schedule { get; set; }

        [ForeignKey("Payment")]
        public int PaymentId { get; set; }

        public Payment Payment { get; set; }



    }
}