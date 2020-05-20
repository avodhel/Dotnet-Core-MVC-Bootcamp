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
                .ForMember(bookVm => bookVm.Author, cfg => cfg.MapFrom((bookEntity) => GetAuthors(bookEntity)));

            CreateMap<Book, BookDetailViewModel>()
                //.ForMember(x => x.PublisherName, y => y.MapFrom(entity => entity.Publisher.Name))
                .ForMember(x => x.PublisherItem, y => y.MapFrom(entity => GetPublisherItem(entity.Publisher)))
                .ForMember(x => x.Authors, y => y.MapFrom(entity => GetAuthorItems(entity)));

            CreateMap<Book, BookUpdateViewModel>()
                .ForMember(x => x.AuthorIds, y => y.MapFrom(entity => GetAuthorIds(entity.BookAuthors)));

            CreateMap<BookUpdateViewModel, Book>()
                .ForMember(x => x.BookAuthors, y => y.MapFrom(model => GetBookAuthor(model.AuthorIds, model.BookId)));
        }

        private string GetAuthors(Book book)
        {
            var authors = string.Empty;
            foreach (var bookAuthor in book.BookAuthors)
            {
                authors += bookAuthor.Author.Name + " " + bookAuthor.Author.Surname + ", ";
            }
            if (!string.IsNullOrWhiteSpace(authors))
            {
                authors = authors.Substring(0, authors.Length - 2);
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

        private PublisherItem GetPublisherItem(Publisher publisher)
        {
            if (publisher == null)
            {
                return null;
            }
            var publisherItem = new PublisherItem()
            {
                PublisherId = publisher.PublisherId,
                PublisherName = publisher.Name
            };
            return publisherItem;
        }

        private List<int> GetAuthorIds(ICollection<BookAuthor> bookAuthor)
        {
            var authorIds = new List<int>();
            foreach (var item in bookAuthor)
            {
                authorIds.Add(item.AuthorId);
            }
            return authorIds;
        }

        private List<BookAuthor> GetBookAuthor(List<int> authorIds, int bookId)
        {
            var bookAuthorList = new List<BookAuthor>();
            foreach (var authorId in authorIds)
            {
                bookAuthorList.Add(new BookAuthor
                {
                    AuthorId = authorId,
                    BookId = bookId
                });
            }
            return bookAuthorList;
        }
    }
}
