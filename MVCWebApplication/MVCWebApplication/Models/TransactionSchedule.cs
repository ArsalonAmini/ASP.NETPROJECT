using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCWebApplication.Models
{
    public class TransactionSchedule
    {

        [Key]

        public int id { get; set; }

        [ForeignKey("Transaction")]

        public int TransactionId { get; set; }

        public Transaction Transaction { get; set; }

        [ForeignKey("Schedule")]

        public int ScheduleId { get; set; }

        public Schedule Schedule { get; set; }
    }
}