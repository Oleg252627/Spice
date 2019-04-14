using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eczamen.Entitie;
using Eczamen.Models;
using Eczamen.Models.Utility;
using Eczamen.Repositories.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;

namespace Eczamen.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.ManagerUser)]
    [Area("Admin")]
    public class MenuItemController : Controller
    {
        private readonly IMenuItemRepository iMenuItemRepository;
        private readonly ISubCategoryRepositiry iSubCategoryRepositiry;
        private readonly ICategoryRepository iCategoryRepository;
        private readonly IHostingEnvironment iEnvironment;

        public MenuItemController(IMenuItemRepository iMenuItemRepository, ICategoryRepository iCategoryRepository,ISubCategoryRepositiry iSubCategoryRepositiry, IHostingEnvironment iEnvironment)
        {
            this.iMenuItemRepository = iMenuItemRepository;
            this.iSubCategoryRepositiry = iSubCategoryRepositiry;
            this.iCategoryRepository = iCategoryRepository;
            this.iEnvironment = iEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            return View(await iMenuItemRepository.GetAllMenuItem());
        }

        public async Task<IActionResult> Create()
        {
            return View(await iMenuItemRepository.CreateNenuItemGet(iCategoryRepository, iSubCategoryRepositiry));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MenuItemModel model)
        {
            if (ModelState.IsValid)
            {
                if (!await iMenuItemRepository.CreateMenuItemPost(model))
                {
                    return NotFound();
                }
                else
                {
                    string webRootPath = iEnvironment.WebRootPath;
                    var file = HttpContext.Request.Form.Files;
                    await iMenuItemRepository.AddImageMenuItem(webRootPath, file);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(await iMenuItemRepository.ExistMenuItem(model, iCategoryRepository, iSubCategoryRepositiry));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            MenuItemModel model = await iMenuItemRepository.EditMenuItemGet(id, iCategoryRepository, iSubCategoryRepositiry);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MenuItemModel model)
        {
            if (ModelState.IsValid)
            {
                if (!await iMenuItemRepository.EditMenuItemPost(model))
                {
                    return NotFound();
                }
                else
                {
                    var file = HttpContext.Request.Form.Files;
                    if (file.Count > 0)
                    {
                        string webRootPath = iEnvironment.WebRootPath;
                        await iMenuItemRepository.EditImageMenuItem(model.Id, webRootPath, file);
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(await iMenuItemRepository.ExistMenuItem(model, iCategoryRepository, iSubCategoryRepositiry));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            MenuItem menuItem = await iMenuItemRepository.DeleteMenuItemGet(id);
            if (menuItem == null)
            {
                return NotFound();
            }
            return View(menuItem);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(MenuItem menuItem)
        {
            if (!await iMenuItemRepository.DeleteMenuItemPost(menuItem, iEnvironment.WebRootPath))
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            MenuItem menuItem = await iMenuItemRepository.DeleteMenuItemGet(id);
            if (menuItem == null)
            {
                return NotFound();
            }
            return View(menuItem);
        }
    }
}