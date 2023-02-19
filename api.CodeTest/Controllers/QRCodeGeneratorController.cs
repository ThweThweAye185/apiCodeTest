using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using api.CodeTest.DAL;
using api.CodeTest.DAL.Models;
using api.CodeTest.DAL.Repositories.Interfaces;
using api.CodeTest.DAL.Services.Interfaces;
using api.CodeTest.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using api.CodeTest.BusinessLayer;

namespace api.CodeTest.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class QRCodeGeneratorController : ControllerBase
    {
        #region Variable 
        private readonly ILogger _logger;
        private readonly IQRCodeGenerator _qrcode;

        CultureInfo provider = CultureInfo.InvariantCulture;
        #endregion

        #region Constructor
        public QRCodeGeneratorController( IQRCodeGenerator qrcode, ILogger<QRCodeGeneratorController> logger)
        {
            _logger = logger;
            _qrcode = qrcode;
        }

        #endregion

        #region CRUD for QRCode
        [HttpPost]
        [Route("generateQRCode")]
        public async Task<IActionResult> GenerateQRCode(string code)
        {
            try
            {
                var qrcode = _qrcode.GenerateQRCode(code);
                if (qrcode == null)
                {
                    return BadRequest("No data found");
                }
                else
                {
                    return Ok(qrcode);
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
