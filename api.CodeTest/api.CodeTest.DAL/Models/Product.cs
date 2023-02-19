using Retail.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace api.CodeTest.DAL.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public decimal Amount { get; set; }
        public int Quantity { get; set; }
        public byte[] memberQRCode { get; set; }
        public byte[] couponQRCode { get; set; }
        public int MaxEVoucher { get; set; }
        public int MaxEVoucherPerUser { get; set; }
        public ICollection<BuyProduct> BuyType { get; set; }
        public ICollection<Promotion> Promotion { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}
