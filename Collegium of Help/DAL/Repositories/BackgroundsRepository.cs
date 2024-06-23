using Collegium_of_Help.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collegium_of_Help.DAL.Repositories
{
    static class BackgroundsRepository
    {
        public static BackgroundModel GetById(int id)
        {
            using (var db = new AppDBContext())
            {
                var background = db.Backgrounds.Single(e => e.Id == id);
                return new BackgroundModel(background);
            }
        }
    }
}
