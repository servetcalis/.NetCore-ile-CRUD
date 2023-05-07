using _20230408_AsyncProgramming_CRUD.Infrastructure.Extensions.Classes;
using _20230408_AsyncProgramming_CRUD.Infrastructure.Extensions.Enums;
using _20230408_AsyncProgramming_CRUD.Infrastructure.Repositories.Interfaces;
using _20230408_AsyncProgramming_CRUD.Models.DTOs;
using _20230408_AsyncProgramming_CRUD.Models.Entities.Abstract;
using _20230408_AsyncProgramming_CRUD.Models.Entities.Concrete;
using _20230408_AsyncProgramming_CRUD.Models.VMs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace _20230408_AsyncProgramming_CRUD.Controllers
{
    public class PageController : Controller
    {
        private readonly IPageRepository _pageRepository;
        private readonly IMapper _mapper;

        public PageController(IPageRepository pageRepository, IMapper mapper)
        {
            this._pageRepository = pageRepository;
            this._mapper = mapper;
        }

        //public IActionResult Create()
        //{
        //    return View();
        //}
        public IActionResult Create() => View();


        [HttpPost]
        public async Task<IActionResult> Create(CreatePageDTO model)
        {
            if (ModelState.IsValid) // Parametre olarak gelen model içerisindeki model üyelere koyulan kurallara uyuldu mu ?
            {
                // Veri tabanındaki page tablosuna sadece "page" tipinde veri ekleyebiliriz. Bu action metoduna gelen veri tipi "CreatePageDTO" olduğundan direkt veri tabanındaki tabloya ekleyemeyiz. Bu yüzden DTO'dan gelen veriyi AutoMapper 3rd aracı ile Page varlığında üyeleri eşitliyoruz.
                var page = _mapper.Map<Models.Entities.Concrete.Page>(model);

                // Kullanıcıdan gelen data model ile buraya taşındı ve Page tipindeki page objesi ile dolduruldu. Artık oluşturulan repository ile veri tabanına ekleme işlemini gerçekleştirebiliriz.

                await _pageRepository.Add(page);
                TempData["Message"] = ExAlert.Create("The page has been created.", AlertType.success);
                return RedirectToAction("List");
            }

            TempData["Message"] = ExAlert.Create("The page hasn't been created.", AlertType.danger);
            return View(model);
        }

        public async Task<IActionResult> List()
        {
            var pages = await _pageRepository.GetFilteredList(
                 select: s => new PageVM
                 {
                     Id = s.Id,
                     Content = s.Content,
                     Status = s.Status,
                     Title = s.Title
                 },
                where: w => w.Status != Status.Passive,
                orderBy: o => o.OrderBy(x => x.Id)

                );

            return View(pages);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            var page = await _pageRepository.GetById(id);
            if (page == null)
            {
                return NotFound();
            }
            var delete = await _pageRepository.Delete(page);
            if (delete)
                TempData["Message"] = ExAlert.Create("The page has been deleted.", AlertType.success);
            else
                TempData["Message"] = ExAlert.Create("The page hasn't been deleted.", AlertType.danger);
            return RedirectToAction("List");

        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            var page = await _pageRepository.GetById(id);
            if (page == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<UpdatePageDTO>(page);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdatePageDTO model)
        {
            if (ModelState.IsValid)
            {
                var page = _mapper.Map<Models.Entities.Concrete.Page>(model);
                await _pageRepository.Update(page);
                TempData["Message"] = ExAlert.Create("The page has been updated", AlertType.success);
                return RedirectToAction("List");
            }
            else
            {
                TempData["Message"] = ExAlert.Create("The page hasn't been updated", AlertType.danger);
            }

            return View(model);
        }

    }
}
