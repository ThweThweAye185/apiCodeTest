using Retail.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Text;

namespace api.CodeTest.DAL.Models
{
    public class BuyProduct : BaseEntity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string BuyTypeStatus { get; set; }
        public string CardNumber { get; set; }
        public string ProductId { get; set; }
        public decimal Amount { get; set; }
        public Product Product { get; set; }
    }
}
