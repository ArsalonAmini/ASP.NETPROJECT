﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCWebApplication.Models
{
    public class Service
    {
        [Key]

        public int id { get; set; }

        public string Name { get; set; }


    }
}