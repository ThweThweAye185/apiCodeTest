using api.CodeTest.DAL.Models.Interfaces;
using Retail.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace api.CodeTest.DAL.Models
{
    public class TransactionAudit : BaseEntity
    {
        //[Key]
        //public string Id { get; set; }
        public string TransactionStatus { get; set; }
        public string ProductId { get; set; }
        public string PhoneNumber { get; set;}
        public decimal Amount { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public DateTime LogDate { get; set; }
        public string CardNumber { get; set; }
    }
}
