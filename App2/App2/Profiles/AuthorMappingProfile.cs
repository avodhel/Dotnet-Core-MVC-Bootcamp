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
            //Detail
            CreateMap<Author, AuthorDetailViewModel>()
                .ForMember(x => x.NameAndSurname, y => y.MapFrom(entity => entity.Name + " " + entity.Surname))
                .ForMember(x => x.Books, y => y.MapFrom(entity => GetBooks(entity)));
            //Author List
            CreateMap<Author, AuthorIndexViewModel>();
        }

        public List<string> GetBooks(Author author)
        {
            var books = new List<string>();
            foreach (var bookAuthor in author.BookAuthors)
            {
                books.Add(bookAuthor.Book.Name);
            }
            return books;
        }
    }
}
