using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Eczamen.Entitie;
using Microsoft.AspNetCore.Mvc;
using Eczamen.Models;
using Eczamen.Models.Utility;
using Eczamen.Repositories.HomView.interfacesHome;
using Eczamen.Repositories.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Eczamen.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ICategoryRepository iCategoryRepository;
        private readonly ISubCategoryRepositiry iSubCategoryRepositiry;
        private readonly IMenuItemRepository iMenuItemRepository;
        private readonly ICouponRepository iCouponRepository;
        private readonly IHomeIndex iHomeIndex;
        private readonly IShoppingCartRepository iShoppingCartRepository;

        public HomeController(ICategoryRepository iCategoryRepository, ISubCategoryRepositiry iSubCategoryRepositiry,
            IMenuItemRepository iMenuItemRepository, ICouponRepository iCouponRepository,
            IHomeIndex iHomeIndex, IShoppingCartRepository iShoppingCartRepository)
        {
            this.iCategoryRepository = iCategoryRepository;
            this.iSubCategoryRepositiry = iSubCategoryRepositiry;
            this.iMenuItemRepository = iMenuItemRepository;
            this.iCouponRepository = iCouponRepository;
            this.iHomeIndex = iHomeIndex;
            this.iShoppingCartRepository = iShoppingCartRepository;
        }

        public async Task<IActionResult> Index()
        {
            IndexViewModel index =
                await iHomeIndex.GetModelIndex(iCategoryRepository, iCouponRepository, iMenuItemRepository);
            var claim = GetClaim();
            if (claim != null)
            {
               AddSession(claim);
            }
               
            return View(index);
        }

        private async void AddSession(Claim claim)
        {
            HttpContext.Session.SetInt32(SD.ssShoppingCartCount,await iShoppingCartRepository.CountShoppingCart(claim.Value));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            ShoppingCart shoppingCart = await iShoppingCartRepository.DetailsShoppingCartGet(id, iMenuItemRepository);
            if (shoppingCart == null)
            {
                return NotFound();
            }

            return View(shoppingCart);
        }

        [Authorize]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Details(ShoppingCart cart)
        {
            if (ModelState.IsValid)
            {
                var claim = GetClaim();
                if (!await iShoppingCartRepository.DetailsShoppingCartPost(cart, claim))
                {
                    return NotFound();
                }
                
                AddSession(claim);
                return RedirectToAction(nameof(Index));
            }

            return View(await iShoppingCartRepository.DetailsShoppingCartGet(cart.MenuItemId, iMenuItemRepository));
        }

        private Claim GetClaim()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
           return claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        }
    }
}
