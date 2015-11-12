using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminControl.Models
{
    public class OrderViewModel
    {
        public string orderId { get; set; }
        public UserViewModel customer { get; set; }
        public string status { get; set; }
        public float totalAmount { get; set; }
        public string summary { get; set; }
        public DateTime createdAt { get; set; }
    }
}