using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App1.Context;
using App1.Entities;

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
    }
}
