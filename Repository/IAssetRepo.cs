using AssetManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Repository
{
    public interface IAssetRepo
    {
        //get all assets
        Task<List<AssetMaster>> GetAssets();

        //get single asset by id
        Task<AssetMaster> GetAsset(int id);

        //add new user
        Task<AssetMaster> AddAsset(AssetMaster asset);

        //update user
        Task<AssetMaster> UpdateAsset(AssetMaster asset);

        //delete user
        Task<AssetMaster> DeleteAsset(int id);
    }
}
