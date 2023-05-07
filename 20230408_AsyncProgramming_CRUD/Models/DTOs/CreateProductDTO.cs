using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _20230408_AsyncProgramming_CRUD.Models.DTOs
{
    public class CreateProductDTO
    {
        public int Id { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Lütfen ürün adını giriniz.")]
        [MinLength(3, ErrorMessage = "Min. 3 karakter giriniz.")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Lütfen ürün fiyatını giriniz.")]
        [Column("decimal(4,2)")]
        public decimal UnitPrice { get; set; }
        public string Image { get; set; }


        [Display(Name = "Choose Category")]
        [Required(ErrorMessage = "Lütfen bir kategori seçiniz.")]
        public int CategoryId { get; set; }

    }
}
