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
    static class EquipmentRepository
    {
        public static ObservableCollection<EquipmentModel> GetAll()
        {
            ObservableCollection<EquipmentModel> result = new ObservableCollection<EquipmentModel>();
            using (var db = new AppDBContext())
            {
                var equipment = db.Equipment.ToList();
                foreach (var item in equipment)
                {
                    result.Add(new EquipmentModel(item));
                }
            }
            return result;
        }
    }
}
