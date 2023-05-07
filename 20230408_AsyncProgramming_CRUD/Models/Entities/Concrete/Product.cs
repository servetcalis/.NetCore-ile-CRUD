using _20230408_AsyncProgramming_CRUD.Models.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace _20230408_AsyncProgramming_CRUD.Models.Entities.Concrete
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public string Image { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
