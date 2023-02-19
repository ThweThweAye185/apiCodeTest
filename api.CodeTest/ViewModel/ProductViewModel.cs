using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.CodeTest.ViewModel
{
    public class ProductViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ExpiryDate { get; set; }
        public string Image { get; set; }
        public decimal Amount { get; set; }
        public int  Quantity { get; set; }
        public bool IsAvailable { get; set; }
        public string QRCode { get; set; }
        public int MaxEVoucher { get; set; }
        public int MaxEVoucherPerUser { get; set; }
    }
    public class ProductSelectViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ExpiryDate { get; set; }
        public byte[] Image { get; set; }
        public decimal Amount { get; set; }
        public int Quantity { get; set; }
        public bool IsAvailable { get; set; }
        public byte[] QRCode { get; set; }
        public int MaxEVoucher { get; set; }
        public int MaxEVoucherPerUser { get; set; }
    }
    public class BuyProductViewModel
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string BuyTypeStatus { get; set; }
        public string OrderNumber { get; set; }
        public string OrderDate { get; set; }
        public string PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public decimal Quantity { get; set; }
        public string PaymentType { get; set; }
        public string PaymentTypeId { get; set; }
        public string TransactinId { get; set; }
        public string CardNumber { get; set; }
        public string ProductId { get; set; }
        public string Status { get; set; }

    }

    public class UpdateProductViewModelResponse
    {
        public bool IsAvailable { get; set; }
    }

    public class TransactionAuditViewModel
    {
        public string TransactionStatus { get; set; }
        public string ProdcutId { get; set; }
        public string PhoneNumber { get; set; }
        public string Amount { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public DateTime LogDate { get; set; }
    }
}
