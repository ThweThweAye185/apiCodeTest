using AutoMapper;
using api.CodeTest.DAL.Models;
using api.CodeTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.CodeTest.MapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<Product, ProductSelectViewModel>();
        }
    }
}
