using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Services.Models
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("FirstName")]
        public string FirstName { get; set; }

        [BsonElement("LastName")]
        public String LastName { get; set; }

        [BsonElement("Age")]
        public int Age { get; set; }

        [BsonElement("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

    }
}
