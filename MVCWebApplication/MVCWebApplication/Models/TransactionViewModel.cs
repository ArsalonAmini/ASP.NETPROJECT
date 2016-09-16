using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebApplication.Models
{
    public class TransactionViewModel
    {

      public Transaction Transaction { get; set; }

        public Service Service { get; set; }

        public Schedule Schedule { get; set; }
        
    }
}