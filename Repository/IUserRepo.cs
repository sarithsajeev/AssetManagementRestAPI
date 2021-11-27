using AssetManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Repository
{
    public interface IUserRepo
    {
        //get all users
        Task<List<UserRegistration>> GetUsers();

        //get single user by id
        Task<UserRegistration> GetUser(int id);

        //add new user
        Task<UserRegistration> AddUser(UserRegistration user);

        //update user
        Task<UserRegistration> UpdateUser(UserRegistration user);

        //delete user
        Task<UserRegistration> DeleteUser(int id);
    }
}
