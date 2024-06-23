using Collegium_of_Help.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collegium_of_Help.DAL.Repositories
{
    internal class ClassesRepository
    {
        public static ClassModel GetById(int id)
        {
            using (var db = new AppDBContext())
            {
                var @class = db.Classes.Single(e => e.Id == id);
                return new ClassModel(@class);
            }
        }
    }
}
