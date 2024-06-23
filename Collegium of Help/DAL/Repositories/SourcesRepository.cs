using Avalonia.Metadata;
using Collegium_of_Help.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collegium_of_Help.DAL.Repositories
{
    static class SourcesRepository
    {
        public static ObservableCollection<SourceModel> GetAll()
        {
            ObservableCollection<SourceModel> result = new ObservableCollection<SourceModel>();
            using (var db = new AppDBContext())
            {
                var sources = db.Sources.ToList();
                foreach(var source in sources)
                {
                    result.Add(new SourceModel(source));
                }
            }
            return result;
        }

        public static SourceModel GetById(int id)
        {
            using (var db = new AppDBContext())
            {
                var source = db.Sources.Single(x => x.Id == id);
                return new SourceModel(source);
            }
        }
    }
}
