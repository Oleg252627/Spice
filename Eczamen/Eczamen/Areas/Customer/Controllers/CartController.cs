using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Eczamen.Models;
using Eczamen.Models.Utility;
using Eczamen.Repositories.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eczamen.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly IShoppingCartRepository _iShoppingCartRepository;
        private readonly IOrderHeaderRepository _iOrderHeaderRepository;
        private readonly IOrderDetailsRepository _iOrderDetailsRepository;
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly ICouponRepository _couponRepository;
        [BindProperty]
        public OrderDetailsCart OrderDetailsCart { get; set; }

        public CartController(IShoppingCartRepository iShoppingCartRepository, IOrderHeaderRepository iOrderHeaderRepository,
            IOrderDetailsRepository iOrderDetailsRepository, IMenuItemRepository menuItemRepository, ICouponRepository couponRepository)
        {
            _iShoppingCartRepository = iShoppingCartRepository;
            _iOrderHeaderRepository = iOrderHeaderRepository;
            _iOrderDetailsRepository = iOrderDetailsRepository;
            _menuItemRepository = menuItemRepository;
            _couponRepository = couponRepository;
        }

        public async Task<IActionResult> Index()
        {
            Claim claimIdentity = GetClaim();
            string code = HttpContext.Session.GetString(SD.ssCuponCode);
            this.OrderDetailsCart =
                await _iShoppingCartRepository.GetOrderDetailsCart(claimIdentity, _menuItemRepository, code, _couponRepository);
            return View(this.OrderDetailsCart);
        }

        private Claim GetClaim()
        {
            var claimUser = (ClaimsIdentity) this.User.Identity;
            return claimUser.FindFirst(ClaimTypes.NameIdentifier);
        }

        public IActionResult AddCoupon()
        {
            if (OrderDetailsCart.OrderHeader.CouponCode == null)
            {
                this.OrderDetailsCart.OrderHeader.CouponCode = "";
            }
            HttpContext.Session.SetString(SD.ssCuponCode, OrderDetailsCart.OrderHeader.CouponCode);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveCoupon()
        {
            HttpContext.Session.SetString(SD.ssCuponCode, "");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Plus(int cartId)
        {
            if (!await _iShoppingCartRepository.PlusCartRepository(cartId))
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Minus(int cartId)
        {
            var cart = await _iShoppingCartRepository.AllItems.FirstOrDefaultAsync(z => z.Id == cartId);
            if (cart.Count == 1)
            {
                _iShoppingCartRepository.Context.Remove(cart);
                await _iShoppingCartRepository.Context.SaveChangesAsync();
                var cnt = _iShoppingCartRepository.AllItems.Where(x => x.ApplicationUserId == cart.ApplicationUserId)
                    .ToList().Count;
                HttpContext.Session.SetInt32(SD.ssShoppingCartCount, cnt);
            }
            else
            {
                if (!await _iShoppingCartRepository.MinusCartRepository(cartId))
                {
                    return NotFound();
                }
            }
            
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Remove(int cartId)
        {
            var cart = await _iShoppingCartRepository.AllItems.FirstOrDefaultAsync(z => z.Id == cartId);
            _iShoppingCartRepository.Context.Remove(cart);
            await _iShoppingCartRepository.SaveChangesAsync();
            var cnt = _iShoppingCartRepository.AllItems.Where(x => x.ApplicationUserId == cart.ApplicationUserId)
                .ToList().Count;
            HttpContext.Session.SetInt32(SD.ssShoppingCartCount, cnt);

            return RedirectToAction(nameof(Index));
        }
    }
}