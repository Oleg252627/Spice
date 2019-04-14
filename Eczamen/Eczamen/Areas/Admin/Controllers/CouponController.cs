using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eczamen.Entitie;
using Eczamen.Models.Utility;
using Eczamen.Repositories.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eczamen.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.ManagerUser)]
    [Area("Admin")]
    public class CouponController : Controller
    {
        private readonly ICouponRepository iCouponRepository;

        public CouponController(ICouponRepository iCouponRepository)
        {
            this.iCouponRepository = iCouponRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await iCouponRepository.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Coupon coupon)
        {
            if (ModelState.IsValid)
            {
                var file = HttpContext.Request.Form.Files;
                if (!await iCouponRepository.CreateCouponPost(file, coupon))
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(coupon);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            Coupon coupon = await iCouponRepository.EditCouponGet(id);
            if (coupon == null)
            {
                return NotFound();
            }
            return View(coupon);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Coupon model)
        {
            if (ModelState.IsValid)
            {
                var file = HttpContext.Request.Form.Files;
                if (!await iCouponRepository.EditCouponPost(file, model))
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
            Coupon coupon = await iCouponRepository.DeleteCouponGet(id);
            if (coupon == null)
            {
                return NotFound();
            }
            return View(coupon);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Coupon coupon)
        {
            if (!await iCouponRepository.DeleteCoupon(coupon))
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            Coupon coupon = await iCouponRepository.DeleteCouponGet(id);
            if (coupon == null)
            {
                return NotFound();
            }
            return View(coupon);
        }
    }
}