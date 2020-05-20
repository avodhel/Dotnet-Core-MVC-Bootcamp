using App2.Data.Entities;
using App2.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App2.Service.Services
{
    public class AuthorService
    {
        private readonly AuthorRepository _repository;
        private readonly BookAuthorRepository _bookAuthorRepository;

        public AuthorService(AuthorRepository repository, BookAuthorRepository bookAuthorRepository)
        {
            _repository = repository;
            _bookAuthorRepository = bookAuthorRepository;
        }

        public List<Author> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public Author GetById(int id)
        {
            return _repository.GetById(id);
        }

        public int Add(Author author)
        {
            return _repository.Insert(author);
        }

        public int Update(Author author)
        {
            return _repository.Update(author);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            //get related books etc.
            var relatedObjects = _bookAuthorRepository.GetAll().Where(x => x.AuthorId == id);
            //delete related books etc.
            foreach (var r in relatedObjects)
            {
                _bookAuthorRepository.Delete(r);
            }
        }
    }
}
