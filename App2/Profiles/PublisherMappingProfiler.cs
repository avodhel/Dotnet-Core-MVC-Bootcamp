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
            //Add
            CreateMap<PublisherInsertViewModel, Publisher>();

            //Update
            CreateMap<Publisher, PublisherUpdateViewModel>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.PublisherId));

            CreateMap<PublisherUpdateViewModel, Publisher>()
                .ForMember(x => x.PublisherId, y => y.MapFrom(z => z.Id));

            //Detail
            CreateMap<Publisher, PublisherDetailViewModel>()
                .ForMember(x => x.Books, y => y.MapFrom(entity => GetBooks(entity.Books)));
        }

        public List<string> GetBooks(ICollection<Book> books)
        {
            var bookList = new List<string>();
            foreach (var book in books)
            {
                bookList.Add(book.Name);
            }
            return bookList;
        }
    }
}
