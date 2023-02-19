using Retail.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace api.CodeTest.DAL.Models
{
    public class Order : BaseEntity
    {
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Quantity { get; set; }
        public string PaymentTypeId { get; set; }
        public string TransactinId { get; set; }
        public string ProductId { get; set; }
        public string Status { get; set; }
        public Payment Payment { get; set; }
        public Product Product { get; set; }

    }
}
