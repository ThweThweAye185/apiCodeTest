using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.CodeTest.DAL.Models;
using api.CodeTest.DAL.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using api.CodeTest.ViewModel;

namespace api.CodeTest.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(IAuthenticateService authenticateService, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _authenticateService = authenticateService;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("SignIn")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] ApplicationUser user)
        {
            try
            {
                ApplicationUser model = new ApplicationUser();
                ApplicationUser result = await _authenticateService.SignIn(user.UserName, user.PasswordHash);
                if (result == null)
                    return Unauthorized(new ApplicationUser());
                UserViewModel userViewModel = new UserViewModel();
                userViewModel.token = result.Token;                
                return Ok(userViewModel);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshToken(string authenticationToken)
        {
            var principal = _authenticateService.GetPrincipalFromExpiredToken(authenticationToken);
            var username = principal.Identity.Name;

            var user = await _userManager.FindByNameAsync(username);
            if (user == null || user.Token != authenticationToken) return BadRequest();

            string newJwtToken = _authenticateService.GenerateJwtToken(user);
            string newRefreshToken = _authenticateService.GenerateRefreshToken();
            user.RefreshToken = newRefreshToken;
            user.Token = newJwtToken;
            await _authenticateService.UpdateUserAsync(user);
            UserRefreshToken refreshtoken = new UserRefreshToken();
            refreshtoken.refreshToken = newRefreshToken;
            return Ok(refreshtoken);
        }


    }
}