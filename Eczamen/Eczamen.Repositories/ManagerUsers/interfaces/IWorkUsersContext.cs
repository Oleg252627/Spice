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
        Task<List<ApplicationUser>> GetAllUsers(Claim claim);
        Task<bool> LockUser(string id);
        Task<bool> UnLockUser(string id);
        Task<ApplicationUser> GetUserOnTheSite(string email);
    }
}
