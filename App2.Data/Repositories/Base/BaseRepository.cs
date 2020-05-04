﻿using App2.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App2.Data.Repositories.Base
{
    public abstract class BaseRepository<TEntity> : IRespository<TEntity> where TEntity : class
    {
        private readonly BookContext _context;
        public BaseRepository(BookContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            var entity = _context.Find<TEntity>(id);
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            var entities = _context.Set<TEntity>().ToList();
            return entities;
        }

        public TEntity GetById(int id)
        {
            return _context.Find<TEntity>(id);
        }

        public void Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
