using _20230408_AsyncProgramming_CRUD.Models.Entities.Abstract;
using System;

namespace _20230408_AsyncProgramming_CRUD.Models.VMs
{
    public class CategoryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
