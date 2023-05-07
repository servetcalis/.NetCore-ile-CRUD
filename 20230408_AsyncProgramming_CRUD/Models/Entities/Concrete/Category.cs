using _20230408_AsyncProgramming_CRUD.Models.Entities.Abstract;
using System.Collections.Generic;

namespace _20230408_AsyncProgramming_CRUD.Models.Entities.Concrete
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
