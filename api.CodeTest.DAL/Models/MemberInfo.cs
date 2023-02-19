using Retail.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace api.CodeTest.DAL.Models
{
    public class MemberInfo : BaseEntity
    {
        public string memberName{get;set;}
        public string phoneNumber{get;set;}
        public int totalPoints{get;set;}
        public decimal purchaseAmount{get;set;}
        
        public virtual Product Product { get; set; }

    }
}
