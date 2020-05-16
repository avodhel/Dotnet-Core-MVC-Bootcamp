using App3.Models;
using App3.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace App3.Profiles
{
    public class BlogMappingProfile : Profile
    {
        public BlogMappingProfile()
        {
            CreateMap<BlogDto, BlogViewModel>();
                //.ForMember(x => x.Author, y => y.MapFrom(z => z.Author))
                //.ForMember(x => x.Tags, y => y.MapFrom(z => z.Tags));
            CreateMap<BlogPaginationDto, BlogPaginationViewModel>();
        }
    }
}
