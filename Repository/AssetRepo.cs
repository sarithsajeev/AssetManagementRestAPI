using AssetManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Repository
{
    public class AssetRepo : IAssetRepo
    {
        AssetManagementContext db;
        public AssetRepo(AssetManagementContext _db)
        {
            db = _db;
        }

        //single asset
        public async Task<AssetMaster> GetAsset(int id)
        {
            if (db != null)
            {
                return await db.AssetMaster.FirstOrDefaultAsync(em => em.AmId == id);
            }
            return null;
        }


        //all assets
        public async Task<List<AssetMaster>> GetAssets()
        {
            if (db != null)
            {
                return await db.AssetMaster.ToListAsync();
            }
            return null;
        }

        //add asset
        public async Task<AssetMaster> AddAsset(AssetMaster asset)
        {
            if (db != null)
            {
                await db.AssetMaster.AddAsync(asset);
                await db.SaveChangesAsync();
                return asset;
            }
            return null;
        }

        //delete asset
        public async Task<AssetMaster> DeleteAsset(int id)
        {
            if (db != null)
            {
                var user = await db.AssetMaster.FirstOrDefaultAsync(em => em.AmId == id);

                db.Remove(user);
                await db.SaveChangesAsync();
                return user;
            }
            return null;
        }

        //update asset
        public async Task<AssetMaster> UpdateAsset(AssetMaster asset)
        {
            if (db != null)
            {
                db.AssetMaster.Update(asset);
                await db.SaveChangesAsync();
                return asset;
            }
            return null;
        }
    }
}
