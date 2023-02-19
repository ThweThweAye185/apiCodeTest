using api.CodeTest.DAL.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Retail.Model
{
    public class BaseEntity : IBaseEntity
    {
        [MaxLength(36)]
        public string Id { get; set; }   
        public bool Active { get; set; }
        [MaxLength(100)]
        public string CreatedBy { get; set; }
        [MaxLength(100)]
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
