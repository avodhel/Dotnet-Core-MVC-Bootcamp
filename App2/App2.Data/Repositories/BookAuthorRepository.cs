using App2.Data.Context;
using App2.Data.Entities;
using App2.Data.Repositories.Base;

namespace App2.Data.Repositories
{
    public class BookAuthorRepository : BaseRepository<BookAuthor>
    {
        public BookAuthorRepository(BookShopContext context) : base(context)
        {
        }
    }
}
