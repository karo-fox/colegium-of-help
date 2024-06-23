using Collegium_of_Help.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Collegium_of_Help.DAL.Repositories
{
    static class BackgroundsRepository
    {
        public static ObservableCollection<BackgroundModel> GetAll()
        {
            ObservableCollection<BackgroundModel> result = new ObservableCollection<BackgroundModel>();
            using (var db = new AppDBContext())
            {
                var backgrounds = db.Backgrounds.ToList();
                foreach (var background in backgrounds)
                {
                    result.Add(new BackgroundModel(background));
                }
            }
            return result;
        }
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
