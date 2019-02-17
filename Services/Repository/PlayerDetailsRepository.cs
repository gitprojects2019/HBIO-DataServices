using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Services.DbModels;
using Services.Interface;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using System.Data;

namespace Services.Repository
{
    public class PlayerDetailsRepository : IPlayerDetailsRepository
    {
        private ObjectContext _context = null;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="settings"></param>
        public PlayerDetailsRepository(IOptions<Settings> settings)
        {
            _context = new ObjectContext(settings);
        }

        /// <summary>
        /// Method to insert document in collection
        /// </summary>
        /// <param name="playerDetails"></param>
        /// <returns>boolen result</returns>
        public  bool Add(PlayerDetails playerDetails)
        {
            try
            {
                _context.PlayerDetails.InsertOneAsync(playerDetails);
                return true;
            }
            catch (Exception ex)
            {
                Log.Error("Error Mesagge: [ "+ex.Message+ " ] Stack Trace: [ " + ex.StackTrace+" ]");
                return false ;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PlayerDetails>> GetAsync()
        {
            return await _context.PlayerDetails.Find(x => true).ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<PlayerDetails> Get(string id)
        {
            var playerDetails = Builders<PlayerDetails>.Filter.Eq("Id", id);
            return await _context.PlayerDetails.Find(playerDetails).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DeleteResult> Remove(string id)
        {
            var playerDetails = Builders<PlayerDetails>.Filter.Eq("Id", id);
            return await _context.PlayerDetails.DeleteOneAsync(playerDetails);
        }

        //public Task<DeleteResult> Remove()
        //{
        //    throw new NotImplementedException();
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="playerDetails"></param>
        /// <returns></returns>
        public async Task<PlayerDetails> Update(string id, PlayerDetails playerDetails)
        {
            await _context.PlayerDetails.ReplaceOneAsync(x => x.Id == id, playerDetails);
            return Get(id).Result;
        }

        public void BulkInsertData()
        {
            DataTable dt = BusinessLogic.ExcelReader.ImportExcel(); ;
        }
       
    }
}
