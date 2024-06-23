using Collegium_of_Help.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collegium_of_Help.DAL.Repositories
{
    internal class ClassesRepository
    {
        public static ObservableCollection<ClassModel> GetAll()
        {
            ObservableCollection<ClassModel> result = new ObservableCollection<ClassModel>();
            using (var db = new AppDBContext())
            {
                var classes = db.Classes.ToList();
                foreach (var oneclass in classes)
                {
                    result.Add(new ClassModel(oneclass));
                }
            }
            return result;
        }
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
