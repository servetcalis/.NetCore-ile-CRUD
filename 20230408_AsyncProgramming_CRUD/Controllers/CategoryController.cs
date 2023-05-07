using _20230408_AsyncProgramming_CRUD.Infrastructure.Extensions.Classes;
using _20230408_AsyncProgramming_CRUD.Infrastructure.Extensions.Enums;
using _20230408_AsyncProgramming_CRUD.Infrastructure.Repositories.Concrete;
using _20230408_AsyncProgramming_CRUD.Infrastructure.Repositories.Interfaces;
using _20230408_AsyncProgramming_CRUD.Models.DTOs;
using _20230408_AsyncProgramming_CRUD.Models.Entities.Abstract;
using _20230408_AsyncProgramming_CRUD.Models.Entities.Concrete;
using _20230408_AsyncProgramming_CRUD.Models.VMs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace _20230408_AsyncProgramming_CRUD.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> List()
        {
            var pages = await _categoryRepository.GetFilteredList(select:
                s => new CategoryVM
                {
                    Id = s.Id,
                    Name = s.Name,
                    CreateDate = s.CreateDate,
                    Status = s.Status
                },
                where: w => w.Status != Status.Passive,
                orderBy: o => o.OrderBy(X => X.Id)
                );

            return View(pages);
        }

        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<Category>(model);
                await _categoryRepository.Add(category);
                TempData["Message"] = ExAlert.Create("The category has been created.", AlertType.success);
                return RedirectToAction("List");
            }
            TempData["Message"] = ExAlert.Create("The category hasn't been created.", AlertType.danger);
            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            var category = await _categoryRepository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            var delete = await _categoryRepository.Delete(category);
            if (delete)
                TempData["Message"] = ExAlert.Create("The category has been deleted.", AlertType.success);
            else
                TempData["Message"] = ExAlert.Create("The category hasn't been deleted.", AlertType.danger);
            return RedirectToAction("List");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            var category = await _categoryRepository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<UpdateCategoryDTO>(category);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateCategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<Category>(model);
                await _categoryRepository.Update(category);
                TempData["Message"] = ExAlert.Create("The category has been updated", AlertType.success);
                return RedirectToAction("List");
            }
            else
            {
                TempData["Message"] = ExAlert.Create("The category hasn't been updated", AlertType.danger);
            }

            return View(model);
        }
    }
}
