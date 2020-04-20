using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App1.Entities;

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
                },
                new UserEntity{
                    Id=2,
                    Name="Burak",
                    Surname="Koç",
                    BirthDate=new DateTime(1989,6,4),
                    Email="burak@kodluyoruz.com",
                    Gender="Erkek",
                    GithubAccountUrl="https://github.com/hazelcakli"
                },
                new UserEntity{
                    Id=3,
                    Name="Bahar",
                    Surname="Yiğit",
                    BirthDate=new DateTime(1989,6,4),
                    Email="bahar@kodluyoruz.com",
                    Gender="Kadın",
                    GithubAccountUrl="https://github.com/hazelcakli"
                }
            };
        }
    }
}
