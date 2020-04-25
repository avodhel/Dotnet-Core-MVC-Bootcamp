using App1.Context;
using App1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App1.Services
{
    public class UserService
    {
        private readonly UserContext _context;
        public UserService(UserContext context)
        {
            _context = context;
        }

        public void Add(UserEntity entity)
        {
            _context.Users.Add(entity);
        }

        public List<UserEntity> GetAll()
        {
            return _context.Users;
        }

        public UserEntity Get(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public List<UserEntity> Query(int id, string name, string surname)
        {
            return _context.Users.Where(x => x.Id == id ||
                                             x.Name == name ||
                                             x.Surname == surname)
                    .ToList();
        }

        public void Edit(UserEntity entity)
        {
            var entityToUpdate = _context.Users.FirstOrDefault(x => x.Id == entity.Id);
            _context.Users.Remove(entityToUpdate);
            _context.Users.Add(entity);
        }

        internal void Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            _context.Users.Remove(user);
        }
    }
}
