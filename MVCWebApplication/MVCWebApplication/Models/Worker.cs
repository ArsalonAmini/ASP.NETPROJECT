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

        [ForeignKey("ApplicationUser")]

        public int ApplicationUserID { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

    }
}