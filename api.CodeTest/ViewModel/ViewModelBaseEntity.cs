using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.CodeTest.ViewModel
{
    public class ViewModelBaseEntity
    {       
        public string Id { get; set; }
        public bool Active { get; set; }      
        public string CreatedBy { get; set; }     
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
