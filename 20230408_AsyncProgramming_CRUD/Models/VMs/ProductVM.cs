using _20230408_AsyncProgramming_CRUD.Models.Entities.Abstract;
using Microsoft.AspNetCore.Http;

namespace _20230408_AsyncProgramming_CRUD.Models.VMs
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public string Image { get; set; }

        public Status Status { get; set; }
        public string CategoryName { get; set; }
    }
}
