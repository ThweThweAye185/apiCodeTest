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
    public class ProductController : ControllerBase
    {
        #region Variable 
        private readonly ILogger _logger;
        private readonly IProduct _product;

        CultureInfo provider = CultureInfo.InvariantCulture;
        #endregion

        #region Constructor
        public ProductController( IProduct product, ILogger<ProductController> logger)
        {
            _logger = logger;
            _product = product;
        }

        #endregion

        #region CRUD for Product
        [HttpGet]
        [Route("getAllProduct")]
        public async Task<IActionResult> GetAllProduct()
        {
            try
            {
                var product = _product.GetAllProduct();
                if (product == null)
                {
                    return BadRequest("No data found");
                }
                else
                {
                    return Ok(product);
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
