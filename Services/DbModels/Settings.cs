using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.DbModels
{
    public class Settings
    {
        public String connectionString;
        public string Database;
        public IConfiguration iconfigurationroot;
    }
}
