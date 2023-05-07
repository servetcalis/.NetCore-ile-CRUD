using System.ComponentModel.DataAnnotations;

namespace _20230408_AsyncProgramming_CRUD.Models.DTOs
{
    public class CreateCategoryDTO
    {
        public int Id { get; set; }

        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Lütfen kategori adını giriniz.")]
        [MinLength(3, ErrorMessage = "Min. 3 karakter giriniz.")]
        [RegularExpression(@"^[a-zA-Z- ]+$", ErrorMessage = "Yalnızca harf giriniz.")]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
