using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Models
{
    public class PlayerDetails
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string RegistrationId { get; set; }
        public string GovernmentId { get; set; }
        public string GovernmentIdType { get; set; }
        public string Age { get; set; }
        public string Weight { get; set; }
        public string ContactNumber { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Gender { get; set; }
        public string TournamentName { get; set; }
        public string TournamentDate { get; set; }
    }
}