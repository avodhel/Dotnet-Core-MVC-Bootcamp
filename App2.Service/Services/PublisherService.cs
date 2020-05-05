using App2.Data.Entities;
using App2.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Service.Services
{
    public class PublisherService
    {
        private readonly PublisherRepository _repository;
        public PublisherService(PublisherRepository repository)
        {
            _repository = repository;
        }

        public Publisher GetById(int id)
        {
            return _repository.GetById(id);
        }

        public int Insert(Publisher publisher)
        {
            return _repository.Insert(publisher);
        }

        public int Update(Publisher publisher)
        {
            return _repository.Update(publisher);
        }
    }
}
