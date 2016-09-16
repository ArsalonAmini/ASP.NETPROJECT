using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCWebApplication.Models
{
    public class TransactionService
    {
        [Key]

        public int id { get; set; }

        [ForeignKey("Transaction")]

        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }

        [ForeignKey("Service")]

        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}