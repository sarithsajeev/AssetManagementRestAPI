using AssetManagement.Models;
using AssetManagement.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AssetManagementContext _context;
        IUserRepo userRepo;
        public UserController(AssetManagementContext context, IUserRepo _c)
        {
            userRepo = _c;
            this._context = context;
        }

        //get all users
        #region get courses
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await userRepo.GetUsers();
            Console.WriteLine(users);
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        #endregion

        //get course by id
        #region single course
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await userRepo.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        #endregion

        //add course
        #region add 
        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] UserRegistration user)
        {
            try
            {
                UserRegistration added = await userRepo.AddUser(user);
                if (added.UId > 0)
                {
                    return Ok(added);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #endregion

        //update 
        #region update
        [HttpPut]
        public async Task<IActionResult> UpdateCourse([FromBody] UserRegistration user)
        {
            try
            {
                UserRegistration added = await userRepo.UpdateUser(user);
                if (added.UId > 0)
                {
                    return Ok(added);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #endregion

        //delete
        #region delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            try
            {
                UserRegistration user = await userRepo.DeleteUser(id);
                if (user.UId>0)
                {
                    return Ok(user);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #endregion
    }
}
