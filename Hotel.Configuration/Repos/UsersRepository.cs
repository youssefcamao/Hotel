﻿using Dapper;
using Hotel.Configuration.Interfaces.Models;
using Hotel.Configuration.Interfaces.Repos;
using Hotel.Configuration.Models.DapperModels;
using System.Data;
using System.Reflection;

namespace Hotel.Configuration.Repos
{
    public class UsersRepository : IUserRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public UsersRepository(ISqlDataAccess dataAccess)
        {
            if (dataAccess == null)
            {
                throw new ArgumentNullException(nameof(dataAccess));
            }
            _dataAccess = dataAccess;
        }
        public void CreateNewModel(IUser model, string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password));
            }
            _dataAccess.SaveData("InsertUser", new
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = password,
                IsUserAdmin = model.IsUserAdmin
            });
        }

        public void DeleteModel(IUser model) =>
            _dataAccess.SaveData("DeleteUser", new { UserId = model.Id});
        

        public IList<IUser> GetAll()
        {
            var dapperUsers = _dataAccess.LoadData<DapperUser, dynamic>("GetAllUsers", new { });
            var users = dapperUsers.Select(x => x is IUser user ? user : throw new ArgumentException("user doesn't implement the interface IUser")).ToList();
            return users;
        }

        public async Task<IUser?> GetUserWithAuthAsync(string email, string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password));
            }
            else if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(nameof(email));
            }

            var user = await _dataAccess.LoadDataAsync<DapperUser, dynamic>("LoginAuth", new { Email = email, Password = password });
            return user.FirstOrDefault();
        }

        public void UpdateModel(IUser model, string? password) 
        {
            _dataAccess.SaveData("UpdateUsers", new 
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                IsUserAdmin = model.IsUserAdmin,
                Password = password
            });
        }
    }
}
