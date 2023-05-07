using _20230408_AsyncProgramming_CRUD.Infrastructure.Context;
using _20230408_AsyncProgramming_CRUD.Infrastructure.Repositories.Interfaces;
using _20230408_AsyncProgramming_CRUD.Models.Entities.Concrete;

namespace _20230408_AsyncProgramming_CRUD.Infrastructure.Repositories.Concrete
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }




    }
}
