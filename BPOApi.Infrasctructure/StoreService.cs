using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using APIBPO.BPOApi.Infrasctructure.DTO;
using APIBPO.Models;
using Microsoft.EntityFrameworkCore;

namespace APIBPO.BPOApi.Infrasctructure
{
    
    public class StoreService 
    {
        private readonly ObpotestContext _context;
        private static StoreService _storeService;

        private StoreService(ObpotestContext context)
        {
            _context = context;
        }

        public static StoreService GetInstance(IServiceProvider serviceProvider)
        {
            if(_storeService ==null)
            {
                var dbContext= serviceProvider.GetRequiredService<ObpotestContext>();
                _storeService = new StoreService(dbContext);
            }
            return _storeService;

        }

        public async Task<BaseResponse<List<Store>>> GetAllStores()
        {
            try
            {
                var stores = await _context.Stores.ToListAsync();
                return new BaseResponse<List<Store>>((int)HttpStatusCode.OK,"Success",stores);
            }
            catch (Exception ex)
            {
                // Log the exception
                return new BaseResponse<List<Store>>((int)HttpStatusCode.NotFound, $"Error: {ex.Message}", null);
            }
        }
        public async Task<BaseResponse<Store>> GetStoreById(int storeId)
        {
            try
            {
                var store= await _context.Stores.Where(x=>x.StoreId==storeId).FirstOrDefaultAsync();
                return new BaseResponse<Store>((int)HttpStatusCode.OK,"Success",store);
            }
            catch (Exception ex)
            {
                return new BaseResponse<Store>((int)HttpStatusCode.NotFound, $"Error: {ex.Message}", null);
            }
        }



    }
}