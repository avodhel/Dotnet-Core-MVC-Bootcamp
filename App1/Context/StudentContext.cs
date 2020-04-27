using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App1.Entities;

namespace App1.Context
{
    public class StudentContext
    {
        public List<StudentEntity> Students { get; set; }

        public StudentContext()
        {
            Students = new List<StudentEntity>
            {
                new StudentEntity{
                    Id=1,
                    Name="Ayça",
                    Surname="Gedik",
                    Class="12-V",
                    Teacher="Ahmet Boztepe"
                }
            };
        }

    }
}
