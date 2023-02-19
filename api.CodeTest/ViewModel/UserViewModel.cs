using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.CodeTest.ViewModel
{
    public class UserViewModel
    {
       public string token { get; set; }      
    }
    public class UserRefreshToken
    {
      public string refreshToken { get; set; }
    }
}
