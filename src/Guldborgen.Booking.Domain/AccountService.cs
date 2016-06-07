using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        #region Sync

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

        public bool Logout(string username)
        {
            throw new NotImplementedException();
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

        public User GetUserBySession(UserSession userSession)
        {
            return userSession == null ? null : _userRepository.FindById(userSession.UserId);
        }

        public User GetUserById(int id)
        {
            return _userRepository.FindById(id);
        }

        public User GetUserByUsername(string username)
        {
            return _userRepository.FindByUsername(username);
        }

        public IEnumerable<Role> GetUserRoles(int userId)
        {
            return _roleRepository.FindRolesByUserId(userId);
        }

        #endregion

        #region Async

        public async Task<int> LoginAsync(string email, string password)
        {
            var user = await _userRepository.FindByEmailAsync(email);

            if (user == null)
                return 0;

            if (!PasswordStorage.VerifyPassword(password, user.Password))
                return 0;

            return user.Id ?? 0;
        }

        public async Task<bool> LogoutAsync(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<UserSession> GetUserSessionByIdAsync(Guid sessionId)
        {
            return await _sessionRepository.FindBySessionIdAsync(sessionId);
        }

        public async Task AddSessionAsync(UserSession userSession)
        {
            await _sessionRepository.AddAsync(userSession);
        }

        public async Task RemoveSessionAsync(UserSession userSession)
        {
            await _sessionRepository.RemoveAsync(userSession);
        }

        public async Task<User> GetUserBySessionAsync(UserSession userSession)
        {
            if (userSession == null)
                return null;

            return await _userRepository.FindByIdAsync(userSession.UserId);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.FindByIdAsync(id);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _userRepository.FindByUsernameAsync(username);
        }

        public async Task<IEnumerable<Role>> GetUserRolesAsync(int userId)
        {
            return await _roleRepository.FindRolesByUserIdAsync(userId);
        }

        #endregion
    }
}