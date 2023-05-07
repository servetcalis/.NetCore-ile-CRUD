using _20230408_AsyncProgramming_CRUD.Models.DTOs;
using _20230408_AsyncProgramming_CRUD.Models.Entities.Concrete;
using _20230408_AsyncProgramming_CRUD.Models.VMs;
using AutoMapper;

namespace _20230408_AsyncProgramming_CRUD.Models.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Page, CreatePageDTO>().ReverseMap();
            CreateMap<Page, UpdatePageDTO>().ReverseMap();
            CreateMap<Page, PageVM>().ReverseMap();

            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryVM>().ReverseMap();

            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();
            CreateMap<Product, ProductVM>().ReverseMap();
        }
    }
}
