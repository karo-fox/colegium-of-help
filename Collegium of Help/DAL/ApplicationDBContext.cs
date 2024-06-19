using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Collegium_of_Help.Models
{
    public class ApplicationDBContext : DbContext
    {
        private const string CONNECTION_STRING_NAME = "CollegiumOfHelpConnection";

        protected override void OnConfiguring(DbContextOptionsBuilder options) 
            => options.UseMySQL(ConfigurationManager.ConnectionStrings[CONNECTION_STRING_NAME]?.ConnectionString);
    }
}
