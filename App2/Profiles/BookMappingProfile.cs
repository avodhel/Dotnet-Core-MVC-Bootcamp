using AutoMapper;
using App2.Data.Entities;
using App2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App2.Profiles
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            CreateMap<Book, BookViewModel>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.BookId))
                .ForMember(bookVM => bookVM.Publisher, cfg => cfg.MapFrom(bookEntity => bookEntity.Publisher.Name))
                .ForMember(bookVm => bookVm.Author, cfg => cfg.MapFrom((bookEntity) => getAuthors(bookEntity)));

            CreateMap<Book, BookDetailViewModel>()
                .ForMember(x => x.PublisherName, y => y.MapFrom(entity => entity.Publisher.Name))
                .ForMember(x => x.Authors, y => y.MapFrom(entity => GetAuthorItems(entity)));
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

        private List<AuthorItem> GetAuthorItems(Book book)
        {
            var authorItems = new List<AuthorItem>();
            foreach (var bookAuthor in book.BookAuthors)
            {
                var authorItem = new AuthorItem()
                {
                    AuthorId = bookAuthor.AuthorId,
                    NameAndSurname = bookAuthor.Author.Name + " " + bookAuthor.Author.Surname
                };

                authorItems.Add(authorItem);
            }
            return authorItems;
        }
    }
}
