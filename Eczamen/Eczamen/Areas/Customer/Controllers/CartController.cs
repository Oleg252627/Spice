using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Eczamen.Models;
using Eczamen.Repositories.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        [BindProperty]
        public OrderDetailsCart OrderDetailsCart { get; set; }

        public CartController(IShoppingCartRepository iShoppingCartRepository, IOrderHeaderRepository iOrderHeaderRepository,
            IOrderDetailsRepository iOrderDetailsRepository, IMenuItemRepository menuItemRepository)
        {
            _iShoppingCartRepository = iShoppingCartRepository;
            _iOrderHeaderRepository = iOrderHeaderRepository;
            _iOrderDetailsRepository = iOrderDetailsRepository;
            _menuItemRepository = menuItemRepository;
        }

        public async Task<IActionResult> Index()
        {
            Claim claimIdentity = GetClaim();
            return View(await _iShoppingCartRepository.GetOrderDetailsCart(claimIdentity, _menuItemRepository));
        }

        private Claim GetClaim()
        {
            var claimUser = (ClaimsIdentity) this.User.Identity;
            return claimUser.FindFirst(ClaimTypes.NameIdentifier);
        }
    }
}