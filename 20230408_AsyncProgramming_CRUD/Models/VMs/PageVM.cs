using _20230408_AsyncProgramming_CRUD.Models.Entities.Abstract;

namespace _20230408_AsyncProgramming_CRUD.Models.VMs
{
    public class PageVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Status Status { get; set; }
    }
}
