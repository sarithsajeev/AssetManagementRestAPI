using AssetManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Repository
{
    public class UserRepo : IUserRepo
    {
        AssetManagementContext db;
        public UserRepo(AssetManagementContext _db)
        {
            db = _db;
        }

        //single user
        public async Task<UserRegistration> GetUser(int id)
        {
            if (db != null)
            {
                return await db.UserRegistration.FirstOrDefaultAsync(em => em.UId == id);
            }
            return null;
        }

        //all users
        public async Task<List<UserRegistration>> GetUsers()
        {
            if (db != null)
            {
                return await db.UserRegistration.ToListAsync();
            }
            return null;
        }

        //add user
        public async Task<UserRegistration> AddUser(UserRegistration user)
        {
            if (db != null)
            {
                await db.UserRegistration.AddAsync(user);
                await db.SaveChangesAsync();
                return user;
            }
            return null;
        }

        //delete user
        public async Task<UserRegistration> DeleteUser(int id)
        {
            if (db != null)
            {
                var user =  await db.UserRegistration.FirstOrDefaultAsync(em => em.UId == id);

                db.Remove(user);
                await db.SaveChangesAsync();
                return user;
            }
            return null;
        }

        //update user
        public async Task<UserRegistration> UpdateUser(UserRegistration user)
        {
            if (db != null)
            {
                db.UserRegistration.Update(user);
                await db.SaveChangesAsync();
                return user;
            }
            return null;
        }
    }
}
