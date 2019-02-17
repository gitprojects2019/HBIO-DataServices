using MongoDB.Driver;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IPlayerDetailsRepository
    {
        Task<IEnumerable<PlayerDetails>> GetAsync();
        Task<PlayerDetails> Get(string id);
        bool Add(PlayerDetails playerDetails);
        Task<PlayerDetails> Update(string id, PlayerDetails playerDetails);
        Task<DeleteResult> Remove(string id);
        void BulkInsertData();
        //Task<DeleteResult> Remove();
    }
}
