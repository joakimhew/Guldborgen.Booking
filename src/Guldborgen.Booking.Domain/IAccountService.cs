using System;
using System.Collections.Generic;
using Guldborgen.Booking.Common.Models;

namespace Guldborgen.Booking.Domain
{
    public interface IAccountService
    {
        bool IsUserValid(string username, string password);
        int Login(string email, string password);
        bool Logout(string username, string password);

        UserSession GetUserSessionById(Guid sessionId);
        void AddSession(UserSession userSession);

        void RemoveSession(UserSession userSession);

        bool IsSessionValid();
        User GetUserBySession(UserSession session);
        User GetUserById(int id);
        IEnumerable<Role> GetUserRoles(int userId);
    }
}