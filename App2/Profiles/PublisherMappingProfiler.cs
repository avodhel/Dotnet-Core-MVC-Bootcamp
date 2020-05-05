using AutoMapper;
using App2.Data.Entities;
using App2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App2.Profiles
{
    public class PublisherMappingProfile : Profile
    {
        public PublisherMappingProfile()
        {
            //Insert
            CreateMap<PublisherInsertViewModel, Publisher>();
        }
    }
}
