using System;
using System.Collections.Generic;
using System.Text;

namespace api.CodeTest.DAL.Models.Interfaces
{
    public interface IBaseEntity
    {
        string Id { get; set; }
        bool Active { get; set; }
        string CreatedBy { get; set; }
        string UpdatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
    }
}
