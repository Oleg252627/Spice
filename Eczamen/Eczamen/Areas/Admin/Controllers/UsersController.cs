using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Eczamen.AppContext;
using Eczamen.Entitie.AplicUser;
using Eczamen.Models.Utility;
using Eczamen.Repositories.ManagerUsers.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eczamen.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.ManagerUser)]
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWorkUsersContext iContext;

        public UsersController(AppDbContext db, IWorkUsersContext iContext)
        {
            _db = db;
            this.iContext = iContext;
        }

        public async Task<IActionResult> Index()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return View(await iContext.GetAllUsers(_db, claim));
        }

        public async Task<IActionResult> Lock(string id)
        {
            if (!await iContext.LockUser(_db, id))
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> UnLock(string id)
        {
            if (!await iContext.UnLockUser(_db, id))
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}