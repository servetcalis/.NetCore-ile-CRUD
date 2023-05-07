using System.ComponentModel.DataAnnotations;

namespace _20230408_AsyncProgramming_CRUD.Models.DTOs
{
    public class CreatePageDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen sayfa başlığını giriniz.")]
        [MinLength(3, ErrorMessage = "Min. 3 karakter giriniz.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Lütfen sayfa içeriğini giriniz.")]
        [MinLength(5, ErrorMessage = "Min. 5 karakter giriniz.")]
        public string Content { get; set; }
    }
}
