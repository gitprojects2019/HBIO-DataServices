using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Services.Models
{
    public class PlayerDetails
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("registrationId")]
        public string RegistrationId { get; set; }

        [BsonElement("governmentId")]
        public string GovernmentId { get; set; }


        [BsonElement("governmentIdType")]
        public string GovernmentIdType { get; set; }

        [BsonElement("dob")]
        public DateTime DateOfBirth { get; set; }

        [BsonElement("age")]
        public string Age { get; set; }

        [BsonElement("weight")]
        public string Weight { get; set; }

        [BsonElement("contactNumber")]
        public string ContactNumber { get; set; }

        [BsonElement("Name")]
        public string State { get; set; }

        [BsonElement("Name")]
        public string District { get; set; }

        [BsonElement("Name")]
        public string Gender { get; set; }

        [BsonElement("Name")]
        public string TournamentName { get; set; }

        [BsonElement("Name")]
        public DateTime TournamentDate { get; set; }
    }
}