using App2.Data.Entities;
using App2.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App2.Service.Services
{
    public class PublisherService
    {
        private readonly PublisherRepository _publisherRepository;
        private readonly BookRepository _bookRepository;

        public PublisherService(PublisherRepository repository, BookRepository bookRepository)
        {
            _publisherRepository = repository;
            _bookRepository = bookRepository;
        }

        public List<Publisher> GetAll()
        {
            return _publisherRepository.GetAll().ToList();
        }

        public Publisher GetById(int id)
        {
            return _publisherRepository.GetById(id);
        }

        public int Insert(Publisher publisher)
        {
            return _publisherRepository.Insert(publisher);
        }

        public int Update(Publisher publisher)
        {
            return _publisherRepository.Update(publisher);
        }

        public void Delete(int id)
        {
            //get related books and clear their publisher info
            var relatedBooks = _bookRepository.GetAll().Where(x => x.PublisherId == id);
            foreach (var rb in relatedBooks)
            {
                rb.PublisherId = null;
                _bookRepository.Update(rb);
            }
            _publisherRepository.Delete(id);
        }
    }
}
