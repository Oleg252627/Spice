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
        private readonly AppDbContext _db;

        public WorkUsers(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<ApplicationUser>> GetAllUsers(Claim claim)
        {
            return await _db.Users.Where(x => x.Id != claim.Value).ToListAsync();
        }

        public async Task<bool> LockUser(string id)
        {
            if (id == null)
            {
                return false;
            }

            var applicationUser = await _db.Users.FirstOrDefaultAsync(z => z.Id == id);
            if (applicationUser == null)
            {
                return false;
            }
            applicationUser.LockoutEnd = DateTime.Now.AddYears(1000);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<bool> UnLockUser(string id)
        {
            if (id == null)
            {
                return false;
            }

            var applicationUser = await _db.Users.FirstOrDefaultAsync(z => z.Id == id);
            if (applicationUser == null)
            {
                return false;
            }
            applicationUser.LockoutEnd = DateTime.Now;
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<ApplicationUser> GetUserOnTheSite(string email)
        {
            return await _db.Users.Where(z => z.Email == email).FirstOrDefaultAsync();
        }
    }
}
