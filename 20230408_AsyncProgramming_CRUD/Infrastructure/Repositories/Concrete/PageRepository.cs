using _20230408_AsyncProgramming_CRUD.Infrastructure.Context;
using _20230408_AsyncProgramming_CRUD.Infrastructure.Repositories.Interfaces;
using _20230408_AsyncProgramming_CRUD.Models.Entities.Concrete;

namespace _20230408_AsyncProgramming_CRUD.Infrastructure.Repositories.Concrete
{
    public class PageRepository : BaseRepository<Page>, IPageRepository
    {
        public PageRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
