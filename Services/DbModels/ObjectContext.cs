﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.DbModels
{
    public class ObjectContext
    {
        public IConfiguration configuration { get; set; }
        private IMongoDatabase _database = null;

        public ObjectContext(IOptions<Settings> settings)
        {
            configuration = settings.Value.iconfigurationroot;
            settings.Value.connectionString = configuration.GetSection("MongoConnections:Connectionstring").Value;
            settings.Value.Database = configuration.GetSection("MongoConnections:Database").Value;

            var client = new MongoClient(settings.Value.connectionString);
            if (client != null)
            {
                _database = client.GetDatabase(settings.Value.Database);
            }

        }

        public IMongoCollection<PlayerDetails> PlayerDetails
        {
            get
            {
                return _database.GetCollection<PlayerDetails>("PlayerDetails");
            }
        }

        public IMongoCollection<BsonDocument> BsonPlayerDetails
        {
            get
            {
                return _database.GetCollection<BsonDocument>("PlayerDetails");
            }
        }

    }
}
