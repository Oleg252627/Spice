using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Eczamen.AppContext;
using Eczamen.Entitie.AplicUser;

namespace Eczamen.Repositories.ManagerUsers.interfaces
{
    public interface IWorkUsersContext
    {
        Task<List<ApplicationUser>> GetAllUsers(AppDbContext db, Claim claim);
        Task<bool> LockUser(AppDbContext db, string id);
        Task<bool> UnLockUser(AppDbContext db, string id);
    }
}
