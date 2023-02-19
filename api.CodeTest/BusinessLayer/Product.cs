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
using Remotion.Linq.Clauses;

namespace api.CodeTest.BusinessLayer
{
    #region Interface
    public interface IProduct
    {
       ProductSelectViewModel GetAllProduct();
    }

    #endregion

    public class Product : IProduct
    {
        #region Variable 
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        CultureInfo provider = CultureInfo.InvariantCulture;
        #endregion

        #region Constructor
        public Product(IProductRepository productRepository, IMapper mapper, ApplicationDbContext context, IProductService productService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productService = productService;
        }

        #endregion

        #region CRUD for Product
        [HttpGet]
        [Route("getAllProduct")]
        public ProductSelectViewModel GetAllProduct()
        {
            ProductSelectViewModel productSelectViewModel = new ProductSelectViewModel();
            try
            {
                var product =  _productService.GetAll();
                if (product == null)
                {
                    return productSelectViewModel;
                }
                else
                {
                    productSelectViewModel = _mapper.Map<ProductSelectViewModel>(product);
                    return productSelectViewModel;
                }
            }
            catch (Exception)
            {
               return productSelectViewModel;
            }

        }
        #endregion
    }
}