using _20230408_AsyncProgramming_CRUD.Infrastructure.Extensions.Classes;
using _20230408_AsyncProgramming_CRUD.Infrastructure.Extensions.Enums;
using _20230408_AsyncProgramming_CRUD.Infrastructure.Repositories.Concrete;
using _20230408_AsyncProgramming_CRUD.Infrastructure.Repositories.Interfaces;
using _20230408_AsyncProgramming_CRUD.Models.DTOs;
using _20230408_AsyncProgramming_CRUD.Models.Entities.Concrete;
using _20230408_AsyncProgramming_CRUD.Models.VMs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace _20230408_AsyncProgramming_CRUD.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<IActionResult> List()
        {
            var products = await _productRepository.GetFilteredList(select:
                s => new ProductVM
                {
                    Id = s.Id,
                    Name = s.Name,
                    CategoryName = s.Category.Name,
                    Image=s.Image,
                    Status = s.Status,
                    UnitPrice = s.UnitPrice
                },
                where: w=> w.Status != Models.Entities.Abstract.Status.Passive,
                orderBy: o=> o.OrderBy(x=> x.Id)
                );

            return View(products);
        }

        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDTO model)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<Product>(model);
                await _productRepository.Add(product);
                TempData["Message"] = ExAlert.Create("The product has been created.", AlertType.success);
                return RedirectToAction("List");
            }
            TempData["Message"] = ExAlert.Create("The product hasn't been created.", AlertType.danger);
            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            var product = await _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            var delete = await _productRepository.Delete(product);
            if (delete)
                TempData["Message"] = ExAlert.Create("The product has been deleted.", AlertType.success);
            else
                TempData["Message"] = ExAlert.Create("The product hasn't been deleted.", AlertType.danger);
            return RedirectToAction("List");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            var product = await _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<UpdateProductDTO>(product);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateProductDTO model)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<Product>(model);
                await _productRepository.Update(product);
                TempData["Message"] = ExAlert.Create("The product has been updated", AlertType.success);
                return RedirectToAction("List");
            }
            else
            {
                TempData["Message"] = ExAlert.Create("The product hasn't been updated", AlertType.danger);
            }

            return View(model);
        }
    }
}
