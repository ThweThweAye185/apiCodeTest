using Retail.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace api.CodeTest.DAL.Models
{
    public class Promotion : BaseEntity
    {
        public string PromCode { get; set; }
        public string Description { get; set; }
        public Product Product { get; set; }
    }
}
