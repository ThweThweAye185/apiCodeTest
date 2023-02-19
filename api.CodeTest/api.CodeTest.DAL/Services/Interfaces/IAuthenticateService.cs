using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using api.CodeTest.DAL.Models;

namespace api.CodeTest.DAL.Services.Interfaces
{
    public interface IAuthenticateService
    {
        Task<ApplicationUser> SignIn(string _userName, string _password);
        string GenerateJwtToken(ApplicationUser _user);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        Task<ApplicationUser> UpdateUserAsync(ApplicationUser user);
    }
}
