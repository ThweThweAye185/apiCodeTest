using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.CodeTest.ViewModel
{
    public class OTPRequestModel
    {

        [Required]
        public string Mobile { get; set; }
        [Required]
        public int MobileCode { get; set; }
    }
}
