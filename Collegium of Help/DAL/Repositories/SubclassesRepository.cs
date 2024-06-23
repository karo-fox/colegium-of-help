using Collegium_of_Help.Models;
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
    }
}
