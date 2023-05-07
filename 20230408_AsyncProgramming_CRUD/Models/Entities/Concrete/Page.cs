using _20230408_AsyncProgramming_CRUD.Models.Entities.Abstract;

namespace _20230408_AsyncProgramming_CRUD.Models.Entities.Concrete
{
    public class Page : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
