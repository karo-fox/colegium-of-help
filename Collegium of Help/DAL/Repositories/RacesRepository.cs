using Collegium_of_Help.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collegium_of_Help.DAL.Repositories
{
    static class RacesRepository
    {
        public static RaceModel GetById(int id)
        {
            using (var db = new AppDBContext())
            {
                var race = db.Races.Single(e => e.Id == id);
                return new RaceModel(race);   
            }
        }
    }
}
