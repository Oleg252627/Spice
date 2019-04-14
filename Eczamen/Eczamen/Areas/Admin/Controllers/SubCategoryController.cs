using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eczamen.Models;
using Eczamen.Models.Utility;
using Eczamen.Repositories.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eczamen.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.ManagerUser)]
    [Area("Admin")]
    public class SubCategoryController : Controller
    {
        private readonly ICategoryRepository iCategoryRepository;
        private readonly ISubCategoryRepositiry iSubCategoryRepositiry;

        public SubCategoryController(ICategoryRepository iCategoryRepository, ISubCategoryRepositiry iSubCategoryRepositiry)
        {
            this.iCategoryRepository = iCategoryRepository;
            this.iSubCategoryRepositiry = iSubCategoryRepositiry;
        }

        public async Task<IActionResult> Index()
        {
            return View(await iSubCategoryRepositiry.GetListSubCategory());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(await iSubCategoryRepositiry.CreateSubCategoryModel(iCategoryRepository));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(SubCategoryAndCategoryModel model)
        {
            if (ModelState.IsValid)
            {
                SubCategoryAndCategoryModel sub = await iSubCategoryRepositiry.ExistSubCategory(model, iCategoryRepository);
                if (sub != null)
                {
                    return View(sub);
                }
                if (!await iSubCategoryRepositiry.CreatePostSubCategory(model))
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [ActionName("GetSubCategory")]
        public async Task<IActionResult> GetSubCategory(int id)
        {
            return Json(await iSubCategoryRepositiry.GetJsonSubCategory(id));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            SubCategoryAndCategoryModel
                model = await iSubCategoryRepositiry.EditGetSubCategory(id, iCategoryRepository);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SubCategoryAndCategoryModel model)
        {
            if (ModelState.IsValid)
            {
                SubCategoryAndCategoryModel sub = await iSubCategoryRepositiry.ExistSubCategory(model, iCategoryRepository);
                if (sub != null)
                {
                    return View(sub);
                }

                if (!await iSubCategoryRepositiry.EditPostSubCategory(model))
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
            return View(await iSubCategoryRepositiry.DeleteSubCategoryGet(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(SubCategoryModel model)
        {
            if (!await iSubCategoryRepositiry.DeleteSubCategoryPost(model))
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            SubCategoryModel model = await iSubCategoryRepositiry.DeleteSubCategoryGet(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
    }
}