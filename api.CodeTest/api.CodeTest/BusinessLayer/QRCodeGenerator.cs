using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace api.CodeTest.BusinessLayer
{
    #region Interface
    public interface IQRCodeGenerator
    {
       Task<byte[]> GenerateQRCode(string code);
    }

    #endregion

    public class QRCodeGenerator : IQRCodeGenerator
    {
        private readonly IMapper _mapper;

        public QRCodeGenerator(IMapper mapper)
        {
           this._mapper = mapper;
        }

        public async Task<byte[]> GenerateQRCode(string code)
        {
            byte[] imageBytes = null;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("https://api.qrserver.com/v1/create-qr-code/?size=200x200&data=" + code))
                {
                    imageBytes = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                }
            }
            return imageBytes;
        }
       
    }
}
