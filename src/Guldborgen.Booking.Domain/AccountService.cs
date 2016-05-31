using System;
using System.Collections.Generic;
using System.Web;
using Guldborgen.Booking.Common;
using Guldborgen.Booking.Common.Models;
using Guldborgen.Booking.DataAccess;

namespace Guldborgen.Booking.Domain
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ISessionRepository _sessionRepository;

        public AccountService(
            IUserRepository userRepository, 
            ISessionRepository sessionRepository,
            IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _sessionRepository = sessionRepository;
            _roleRepository = roleRepository;
        }

        public bool IsUserValid(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public int Login(string email, string password)
        {
            var user = _userRepository.FindByEmail(email);

            if (user == null)
                return 0;

            if (!PasswordStorage.VerifyPassword(password, user.Password))
                return 0;

            return user.Id ?? 0;
        }

        public bool Logout(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public UserSession GetUserSessionById(Guid sessionId)
        {
            return _sessionRepository.FindBySessionId(sessionId);
        }

        public void AddSession(UserSession userSession)
        {
            _sessionRepository.Add(userSession);
        }

        public void RemoveSession(UserSession userSession)
        {
            _sessionRepository.Remove(userSession);
        }

        public bool IsSessionValid()
        {
            throw new System.NotImplementedException();
        }

        public User GetUserBySession(UserSession session)
        {
            return session == null ? null : _userRepository.FindById(session.UserId);
        }

        public User GetUserById(int id)
        {
            return _userRepository.FindById(id);
        }

        public IEnumerable<Role> GetUserRoles(int userId)
        {
            return _roleRepository.FindRolesByUserId(userId);
        }
    }
}