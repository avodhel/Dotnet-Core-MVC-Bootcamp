using App2.Data.Entities;
using App2.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App2.Profiles
{
    public class AuthorMappingProfile : Profile
    {
        public AuthorMappingProfile()
        {
            //Add
            CreateMap<AuthorInsertViewModel, Author>();
            //Update
            CreateMap<Author, AuthorUpdateViewModel>();
            CreateMap<AuthorUpdateViewModel, Author>();
        }
    }
}
