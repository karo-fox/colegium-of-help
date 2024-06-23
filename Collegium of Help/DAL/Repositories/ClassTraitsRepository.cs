using Collegium_of_Help.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collegium_of_Help.DAL.Repositories
{
    static class ClassTraitsRepository
    {
        public static ObservableCollection<ClassTraitModel> GetTraitsByClassId(int id)
        {
            ObservableCollection<ClassTraitModel> result = new();
            using (var db = new AppDBContext())
            {
                var classTraitsIds = db.ClassClassTraits.Where(e => e.ClassId == id).ToList().ConvertAll(e => e.ClassTraitId);
                if (classTraitsIds.Count == 0)
                {
                    return result;
                }
                var coll = db.ClassTraits.Where(e => classTraitsIds.Contains(e.Id)).ToList();
                foreach (var el in coll)
                {
                    result.Add(new ClassTraitModel(el));
                }
            }
            return result;
        }
        public static ObservableCollection<ClassTraitModel> GetTraitsBySubclassId(int id)
        {
            ObservableCollection<ClassTraitModel> result = new();
            using (var db = new AppDBContext())
            {
                var classTraitsIds = db.SubclassClassTraits.Where(e => e.SubclassId == id).ToList().ConvertAll(e => e.ClassTraitId);
                if (classTraitsIds.Count == 0)
                {
                    return result;
                }
                var coll = db.ClassTraits.Where(e => classTraitsIds.Contains(e.Id)).ToList();
                foreach (var el in coll)
                {
                    result.Add(new ClassTraitModel(el));
                }
            }
            return result;
        }
    }
}
