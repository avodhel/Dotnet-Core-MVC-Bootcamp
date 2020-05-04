using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Data.Repositories.Base
{
    public interface IRespository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        int Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}
