using Retail.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace api.CodeTest.DAL.Models
{
    public class Employee : BaseEntity
    {
        public string empId{get;set;}
        public string empName{get;set;}
        public string phoneNumber{get;set;}
        public string address{get;set;}
        public string position{get;set;}

    }
}
