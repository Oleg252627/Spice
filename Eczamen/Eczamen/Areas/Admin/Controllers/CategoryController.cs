using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Eczamen.Entitie;
using Eczamen.Models;
using Eczamen.Models.Utility;
using Eczamen.Repositories.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;

namespace Eczamen.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.ManagerUser)]
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository icategoryRepository;

        public CategoryController(ICategoryRepository icategoryRepository)
        {
            this.icategoryRepository = icategoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await icategoryRepository.GetAllCategory());
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                if (!await icategoryRepository.CreateCategory(category))
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            CategoryModel model = await icategoryRepository.EditGetCategory(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id, Name")] CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                if (!await icategoryRepository.EditPostCategory(model))
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            CategoryModel model = await icategoryRepository.EditGetCategory(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([Bind("Id, Name")] CategoryModel model)
        {
            
            if (!await icategoryRepository.DeleteCategory(model))
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            CategoryModel model = await icategoryRepository.EditGetCategory(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }
    }
}