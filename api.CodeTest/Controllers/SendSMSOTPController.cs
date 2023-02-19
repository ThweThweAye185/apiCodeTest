using System;
using System.Globalization;
using System.Threading.Tasks;
using api.CodeTest.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using api.CodeTest.BusinessLayer;

namespace api.CodeTest.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SendSMSOTPController : ControllerBase
    {
        #region Variable 
        private readonly ILogger _logger;
        private readonly ISendSMSOTP _sendSMSOTP;

        CultureInfo provider = CultureInfo.InvariantCulture;
        #endregion

        #region Constructor
        public SendSMSOTPController( ISendSMSOTP sendSMSOTP, ILogger<ProductController> logger)
        {
            _logger = logger;
            _sendSMSOTP = sendSMSOTP;
        }

        #endregion

        #region Send SMS OTP
        [HttpPost]
        [Route("sendSMSOTP")]
        public async Task<IActionResult> SendSMSOTP(OTPRequestModel model)
        {
            try
            {
                var sendSMSOTP = _sendSMSOTP.SendSmsOTP( model);
                if (sendSMSOTP == null)
                {
                    return BadRequest(sendSMSOTP);
                }
                else
                {
                    return Ok(sendSMSOTP);
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        #endregion

    }
}
