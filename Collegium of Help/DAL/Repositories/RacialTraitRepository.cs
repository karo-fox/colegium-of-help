using Collegium_of_Help.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collegium_of_Help.DAL.Repositories
{
    static class RacialTraitRepository
    {
        public static ObservableCollection<RacialTraitModel> GetTraitsByRaceId(int id)
        {
            ObservableCollection<RacialTraitModel> result = new();
            using (var db = new AppDBContext())
            {
                var traits = db.RacialTraits.Where(e => e.Race == id).ToList();
                foreach (var trait in traits)
                {
                    result.Add(new RacialTraitModel(trait));
                }
                return result;
            }
            
        }
    }
}
