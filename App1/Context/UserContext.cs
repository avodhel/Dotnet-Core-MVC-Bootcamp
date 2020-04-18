using App1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App1.Context
{
    public class UserContext
    {
        public List<UserEntity> Users { get; set; }

        public UserContext()
        {
            Users = new List<UserEntity> {
                new UserEntity{
                    Id=1,
                    Name="Hazel",
                    Surname="Caklı",
                    BirthDate=new DateTime(1989,6,4),
                    Email="hazel@kodluyoruz.com",
                    Gender="Kadın",
                    GithubAccountUrl="https://github.com/hazelcakli"
                }
            };
        }
    }
}
