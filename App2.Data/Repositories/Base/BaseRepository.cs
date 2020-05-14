using App2.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App2.Data.Repositories.Base
{
    public abstract class BaseRepository<TEntity> : IRespository<TEntity> where TEntity : class
    {
        internal readonly BookShopContext _context;
        public BaseRepository(BookShopContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            var entity = _context.Find<TEntity>(id);
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
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

        public int Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return _context.SaveChanges();
        }

        public int Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges();
        }

        //ilgili nesneye ait sorglanabilir bir tablo verir
        //bu sayede bütün veriler için sorgu dönmektense, sql üzerinde sadece istenen veri için sorgu döner.
        public IQueryable<TEntity> Query()
        {
            return _context.Set<TEntity>().AsQueryable().AsTracking();
        }
    }
}
