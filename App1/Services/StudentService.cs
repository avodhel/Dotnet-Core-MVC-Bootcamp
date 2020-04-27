using System.Collections.Generic;
using System.Linq;
using App1.Context;
using App1.Entities;

namespace App1.Services
{
    public class StudentService
    {
        private readonly StudentContext _context;
        public StudentService(StudentContext context)
        {
            _context = context;
        }
        public List<StudentEntity> GetAllStudent()
        {
            return _context.Students;
        }

        public StudentEntity Get(int id)
        {
            return _context.Students.FirstOrDefault(x => x.Id == id);
        }

        public void Edit(StudentEntity entity)
        {
            var oldEntity = _context.Students.FirstOrDefault(x => x.Id == entity.Id);
            _context.Students.Remove(oldEntity);
            _context.Students.Add(entity);
        }
    }
}
