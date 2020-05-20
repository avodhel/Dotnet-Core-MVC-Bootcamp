using App2.Data.Context;
using App2.Data.Entities;
using App2.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Data.Repositories
{
    public class AuthorRepository : BaseRepository<Author>
    {
        public AuthorRepository(BookShopContext context) : base(context)
        {
        }
    }
}
