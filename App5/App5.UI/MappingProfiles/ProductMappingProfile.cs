using App5.UI.Models.Response;
using App5.UI.Models.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App5.UI.MappingProfiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductResponse, ProductViewModel>();
        }
    }
}
