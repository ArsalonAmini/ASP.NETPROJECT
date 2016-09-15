using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCWebApplication.Models
{
    public class ViewModel
    {
     
            public Customer Customer { get; set; }

            public Country Country { get; set; }

            public State State { get; set; }

            
            public string Street { get; set; }

            public City city { get; set; }

    }
}