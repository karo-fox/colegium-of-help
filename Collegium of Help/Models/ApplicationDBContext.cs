using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Collegium_of_Help.Models
{
    public class ApplicationDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options) 
            => options.UseMySQL("server=localhost;database=colegiumofhelpdb;user=user;password=password");
    }
}
