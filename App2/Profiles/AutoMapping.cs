using AutoMapper;
using App2.Data.Entities;
using App2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App2.Profiles
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Book, BookViewModel>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.BookId))
                .ForMember(bookVM => bookVM.Publisher, cfg => cfg.MapFrom(bookEntity => bookEntity.Publisher.Name))
                .ForMember(bookVm => bookVm.Author, cfg => cfg.MapFrom((bookEntity) => getAuthors(bookEntity)));
        }

        private string getAuthors(Book z)
        {
            var authors = string.Empty;
            foreach (var bookAuthor in z.BookAuthors)
            {
                authors += bookAuthor.Author.Name + " " + bookAuthor.Author.Surname;
            }
            return authors;
        }
    }
}
