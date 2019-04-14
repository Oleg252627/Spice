using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Eczamen.AppContext;
using Eczamen.Entitie.AplicUser;
using Eczamen.Repositories.ManagerUsers.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Eczamen.Repositories.ManagerUsers
{
    public class WorkUsers: IWorkUsersContext
    {
        public async Task<List<ApplicationUser>> GetAllUsers(AppDbContext db, Claim claim)
        {
            return await db.Users.Where(x => x.Id != claim.Value).ToListAsync();
        }

        public async Task<bool> LockUser(AppDbContext db, string id)
        {
            if (id == null)
            {
                return false;
            }

            var applicationUser = await db.Users.FirstOrDefaultAsync(z => z.Id == id);
            if (applicationUser == null)
            {
                return false;
            }
            applicationUser.LockoutEnd = DateTime.Now.AddYears(1000);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> UnLockUser(AppDbContext db, string id)
        {
            if (id == null)
            {
                return false;
            }

            var applicationUser = await db.Users.FirstOrDefaultAsync(z => z.Id == id);
            if (applicationUser == null)
            {
                return false;
            }
            applicationUser.LockoutEnd = DateTime.Now;
            return await db.SaveChangesAsync() > 0;
        }
    }
}
