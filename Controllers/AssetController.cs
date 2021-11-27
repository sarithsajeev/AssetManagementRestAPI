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
    public class AssetController : ControllerBase
    {
        private readonly AssetManagementContext _context;
        IAssetRepo assetRepo;
        public AssetController(AssetManagementContext context, IAssetRepo _c)
        {
            assetRepo = _c;
            this._context = context;
        }

        //get all users
        #region get assets
        [HttpGet]
        public async Task<IActionResult> GetAssets()
        {
            var users = await assetRepo.GetAssets();
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
            var user = await assetRepo.GetAsset(id);
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
        public async Task<IActionResult> AddAsset([FromBody] AssetMaster asset)
        {
            try
            {
                AssetMaster added = await assetRepo.AddAsset(asset);
                if (added.AmId > 0)
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
        public async Task<IActionResult> UpdateAsset([FromBody] AssetMaster asset)
        {
            try
            {
                AssetMaster added = await assetRepo.UpdateAsset(asset);
                if (added.AmId > 0)
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
                AssetMaster user = await assetRepo.DeleteAsset(id);
                if (user.AmId > 0)
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
