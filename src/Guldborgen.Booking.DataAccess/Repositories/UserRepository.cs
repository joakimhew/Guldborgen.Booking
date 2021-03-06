﻿using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Guldborgen.Booking.Common.Models;

namespace Guldborgen.Booking.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _dbConnection;

        public UserRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        #region Sync

        public User FindById(int id)
        {
            return _dbConnection.Query<User>(
                "SELECT U.* " +
                "FROM dbo.[User] U " +
                " WHERE U.Id = @Id", new {@Id = id}).FirstOrDefault();
        }

        public IEnumerable<User> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> Find(string sql)
        {
            throw new System.NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(User entity)
        {
            throw new System.NotImplementedException();
        }

        public void Add(User entity)
        {
            throw new System.NotImplementedException();
        }

        public User FindByEmail(string email)
        {
            return _dbConnection.Query<User>(
               "SELECT U.* " +
               "FROM dbo.[User] U " +
               " WHERE U.Email = @Email", new { @Email = email }).FirstOrDefault();
        }

        public User FindByUsername(string username)
        {
            return _dbConnection.Query<User>(
               "SELECT U.* " +
               "FROM dbo.[User] U " +
               " WHERE U.Username = @Username", new { @Username = username }).FirstOrDefault();
        }

        public string GetUserPasswordHash(string email)
        {
            return _dbConnection
               .Query<string>("SELECT * FROM dbo.tvf_GetUserPasswordHash(@Email)", new { @Email = email })
               .FirstOrDefault();
        }

       

        #endregion

        #region Async


        public async Task<User> FindByIdAsync(int id)
        {
            var result = await _dbConnection.QueryAsync<User>(
                "SELECT U.* " +
                "FROM dbo.[User] U " +
                " WHERE U.Id = @Id", new {@Id = id});

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<User>> FindAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<User>> FindAsync(string sql)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateAsync(User entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task RemoveAsync(User entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task AddAsync(User entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            var result = await _dbConnection.QueryAsync<User>(
                "SELECT U.* " +
                "FROM dbo.[User] U " +
                " WHERE U.Email = @Email", new {@Email = email});

            return result.FirstOrDefault();
        }

        public async Task<User> FindByUsernameAsync(string username)
        {
            var result = await _dbConnection.QueryAsync<User>(
               "SELECT U.* " +
               "FROM dbo.[User] U " +
               " WHERE U.Username = @Username", new { @Username = username });

            return result.FirstOrDefault();
        }

        public async Task<string> GetUserPasswordHashAsync(string email)
        {
            var result = await _dbConnection
               .QueryAsync<string>("SELECT * FROM dbo.tvf_GetUserPasswordHash(@Email)",
               new { @Email = email });

            return result.FirstOrDefault();
        }

        #endregion
    }
}