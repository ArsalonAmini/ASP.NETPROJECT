using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace MVCWebApplication.Models
{
    public class Country
    {
        [Key]

        public int ID { get; set; }

        public string name { get; set; }
    }
}