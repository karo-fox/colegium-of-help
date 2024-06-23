using Collegium_of_Help.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace Collegium_of_Help.DAL.Repositories
{
    static class SubclassesRepository
    {
        public static SubclassModel GetById(int id)
        {
            using (var db = new AppDBContext())
            {
                var subclass = db.Subclasses.Single(x => x.Id == id);
                return new SubclassModel(subclass);
            }
        }
        public static ObservableCollection<SubclassModel> GetSubclassesByClassId(int id)
        {
            ObservableCollection<SubclassModel> result = new();
            using (var db = new AppDBContext())
            {
                var traits = db.Subclasses.Where(e => e.Class == id).ToList();
                foreach (var trait in traits)
                {
                    result.Add(new SubclassModel(trait));
                }
                return result;
            }

        }
    }
}
