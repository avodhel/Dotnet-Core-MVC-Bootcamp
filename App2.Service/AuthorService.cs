using App2.Data.Entities;
using App2.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Service
{
    public class AuthorService
    {
        private readonly AuthorRepository _repository;
        public AuthorService(AuthorRepository repository)
        {
            _repository = repository;
        }

        public int Add(Author author)
        {
            return _repository.Insert(author);
        }
    }
}
