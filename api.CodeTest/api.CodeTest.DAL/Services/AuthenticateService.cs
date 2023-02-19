using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using api.CodeTest.DAL.Core;
using api.CodeTest.DAL.Models;
using api.CodeTest.DAL.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using api.CodeTest.DAL.Core.Interfaces;
using Microsoft.AspNetCore.Authentication;
using api.CodeTest.DAL.Repositories.Interfaces;

namespace api.CodeTest.DAL.Services
{
   public class AuthenticateService : IAuthenticateService
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _userRole;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;      
        public AuthenticateService(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> userRole,
            IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _context = context;
            _signInManager = signInManager;
            _userRole = userRole;
            _context.CurrentUserId = httpContextAccessor.HttpContext?.User.FindFirst(ClaimConstants.Subject)?.Value?.Trim();
            _userManager = userManager;
            _configuration = configuration;         
          
        }

        #region Login
        public async Task<ApplicationUser> SignIn(string _userName, string _password)
        {
            try
            {
                var obj = new ApplicationUser();
                ApplicationUser model = new ApplicationUser();
                obj = await _userManager.FindByNameAsync(_userName);
               
                if (obj.Active == false)
                    throw new Exception("This user locked in system");
                var result = await _signInManager.PasswordSignInAsync(_userName, _password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {                   
                    model.Id = obj.Id;
                    model.UserName = obj.UserName;
                    model.Token = GenerateJwtToken(model);
                    await UpdateUserAsync(model);                   
                    return model;
                }
                else
                {
                    model = null;
                    return model;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
           
        }
        #endregion

        #region Generate JWT Token
        public string GenerateJwtToken(ApplicationUser _user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, _user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, _user.Id)
            };            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expire = DateTime.Now.AddHours(24);

            var token = new JwtSecurityToken(
                issuer: _configuration["Tokens:Issuer"],
                audience : _configuration["Tokens:Issuer"],
                claims,
                expires : expire,
                signingCredentials : cred
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"])),
                ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }
        #endregion

        public async Task<ApplicationUser> UpdateUserAsync(ApplicationUser user)
        {
            var obj = await _userManager.FindByNameAsync(user.UserName);
            obj.Token = user.Token;
            obj.RefreshToken = user.RefreshToken;
            await _userManager.UpdateAsync(obj);
            var result = await _userManager.UpdateAsync(obj);

            if (!result.Succeeded)
                throw new Exception($"Seeding \"{user}\" user failed. Errors: {string.Join(Environment.NewLine, result.Errors)}");
            return obj;

        }
    }
}
