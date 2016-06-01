using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Guldborgen.Booking.Common.Models;

namespace Guldborgen.Booking.Domain
{
    public interface IAccountService
    {
        #region Sync

        int Login(string email, string password);
        bool Logout(string username);

        UserSession GetUserSessionById(Guid sessionId);
        void AddSession(UserSession userSession);
        void RemoveSession(UserSession userSession);
        User GetUserBySession(UserSession userSession);
        User GetUserById(int id);
        IEnumerable<Role> GetUserRoles(int userId);

        #endregion

        #region Async

        Task<int> LoginAsync(string email, string password);
        Task<bool> LogoutAsync(string username);
        Task<UserSession> GetUserSessionByIdAsync(Guid sessionId);
        Task AddSessionAsync(UserSession userSession);
        Task RemoveSessionAsync(UserSession userSession);
        Task<User> GetUserBySessionAsync(UserSession userSession);
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<Role>> GetUserRolesAsync(int userId);

        #endregion

    }
}