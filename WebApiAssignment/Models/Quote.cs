﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiAssignment.Models
{
    public class Quote
    {
        public int QuoteID { get; set; }
        public string QuoteType { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public double Premium { get; set; }
        public string Sales { get; set; }
    }
}