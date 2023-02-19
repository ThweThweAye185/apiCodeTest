using Retail.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace api.CodeTest.DAL.Models
{
    public class ProductItem 
    {
        public string Id{get;set;}
        public string itemType{get;set;}
        public decimal price{get;set;}
        public int qty{get;set;}
        public decimal totalPrice{get;set;}

        public virtual Product Product { get; set; }

    }
}
