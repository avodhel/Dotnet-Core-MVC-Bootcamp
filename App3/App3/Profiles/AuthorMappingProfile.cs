using AutoMapper;
using App3.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App3.Models;
using App3.Service.Dto;

namespace App3.Profiles
{
    public class AuthorMappingProfile : Profile
    {
        public AuthorMappingProfile()
        {
            CreateMap<Author, AuthorIndexViewModel>();
            CreateMap<AuthorBlogSummaryDto, AuthorBlogSummaryViewModel>();
        }
    }
}
