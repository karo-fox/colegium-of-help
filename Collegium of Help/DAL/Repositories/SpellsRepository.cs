using Collegium_of_Help.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collegium_of_Help.DAL.Repositories
{
    static class SpellsRepository
    {
        public static ObservableCollection<SpellModel> GetAll()
        {
            ObservableCollection<SpellModel> result = new ObservableCollection<SpellModel>();
            using (var db = new AppDBContext())
            {
                var spells = db.Spells.ToList();
                foreach (var spell in spells)
                {
                    result.Add(new SpellModel(spell));
                }
            }
            return result;
        }

        public static ObservableCollection<SpellModel> GetSpellsByClassId(int id)
        {
            ObservableCollection<SpellModel> result = new();
            using (var db = new AppDBContext())
            {
                var classTraitsIds = db.ClassSpells.Where(e => e.ClassId == id).ToList().ConvertAll(e => e.SpellId);
                if (classTraitsIds.Count == 0)
                {
                    return result;
                }
                var coll = db.Spells.Where(e => classTraitsIds.Contains(e.Id)).ToList();
                foreach (var el in coll)
                {
                    result.Add(new SpellModel(el));
                }
            }
            return result;
        }

        public static ObservableCollection<SpellModel> GetSpellsBySubclassId(int id)
        {
            ObservableCollection<SpellModel> result = new();
            using (var db = new AppDBContext())
            {
                var classTraitsIds = db.SubclassSpells.Where(e => e.SubclassId == id).ToList().ConvertAll(e => e.SpellId);
                if (classTraitsIds.Count == 0)
                {
                    return result;
                }
                var coll = db.Spells.Where(e => classTraitsIds.Contains(e.Id)).ToList();
                foreach (var el in coll)
                {
                    result.Add(new SpellModel(el));
                }
            }
            return result;
        }
    }
}
