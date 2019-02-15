﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

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

        [BsonElement("state")]
        public string State { get; set; }

        [BsonElement("district")]
        public string District { get; set; }

        [BsonElement("gender")]
        public string Gender { get; set; }

        [BsonElement("tournamentName")]
        public string TournamentName { get; set; }

        [BsonElement("tournamentDate")]
        public DateTime TournamentDate { get; set; }
    }
}