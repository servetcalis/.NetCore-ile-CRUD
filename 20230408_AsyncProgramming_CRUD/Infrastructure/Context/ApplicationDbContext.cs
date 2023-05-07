using _20230408_AsyncProgramming_CRUD.Models.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using _20230408_AsyncProgramming_CRUD.Models.DTOs;
using _20230408_AsyncProgramming_CRUD.Models.VMs;

namespace _20230408_AsyncProgramming_CRUD.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Page> Pages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Migration esnasında "Microsoft.EntityFrameworkCore.Model.Validation[30000]" uyarısını almamak için aşağıdaki komut satırını uygulayabilirsiniz.
            modelBuilder.Entity<Product>().
                Property(x => x.UnitPrice).
                HasColumnType("decimal");
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<_20230408_AsyncProgramming_CRUD.Models.DTOs.UpdatePageDTO> UpdatePageDTO { get; set; }


        public DbSet<_20230408_AsyncProgramming_CRUD.Models.VMs.CategoryVM> CategoryVM { get; set; }


        public DbSet<_20230408_AsyncProgramming_CRUD.Models.DTOs.CreateCategoryDTO> CreateCategoryDTO { get; set; }


        public DbSet<_20230408_AsyncProgramming_CRUD.Models.DTOs.UpdateCategoryDTO> UpdateCategoryDTO { get; set; }


        public DbSet<_20230408_AsyncProgramming_CRUD.Models.VMs.ProductVM> ProductVM { get; set; }


        public DbSet<_20230408_AsyncProgramming_CRUD.Models.DTOs.CreateProductDTO> CreateProductDTO { get; set; }


        public DbSet<_20230408_AsyncProgramming_CRUD.Models.DTOs.UpdateProductDTO> UpdateProductDTO { get; set; }
    }
}
