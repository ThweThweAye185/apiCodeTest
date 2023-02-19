using Retail.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace api.CodeTest.DAL.Models
{
    public class Payment : BaseEntity
    {
        public string PaymentType { get; set; }
        public bool Allowed { get; set; }
        public Order Order { get; set; }
    }
}
