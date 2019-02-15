using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.Interface;
using Services.Models;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerDetailsController : ControllerBase
    {
        private readonly IPlayerDetailsRepository _playerdetailsRepository;

        public PlayerDetailsController(IPlayerDetailsRepository playerdetailsRepository)
        {
            _playerdetailsRepository = playerdetailsRepository;
        }
        // GET: api/PlayerDetails
        [HttpGet]
        public Task<string> Get()
        {
            return this.GetStudent();
        }

        private async Task<string> GetStudent()
        {
            var output = await _playerdetailsRepository.GetAsync();
            return JsonConvert.SerializeObject(output);
        }

        // GET: api/PlayerDetails/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(string id)
        {
            var output = _playerdetailsRepository.Get(id).Result;
            return JsonConvert.SerializeObject(output); ;
        }

        // POST: api/PlayerDetails
        [HttpPost]
        public bool Post([FromBody] PlayerDetails playerDetails)
        {
            return _playerdetailsRepository.Add(playerDetails);
        }

        // PUT: api/PlayerDetails/5
        [HttpPut("{id}")]
        public string Put(string id, [FromBody] PlayerDetails playerDetails)
        {
            var output = _playerdetailsRepository.Update(id, playerDetails);
            return JsonConvert.SerializeObject(output);
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public string Delete(string id)
        {
            var output = _playerdetailsRepository.Remove(id);
            return JsonConvert.SerializeObject(output);

        }
    }
}
