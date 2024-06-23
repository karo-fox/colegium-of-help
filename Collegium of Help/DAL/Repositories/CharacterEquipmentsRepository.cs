using Collegium_of_Help.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collegium_of_Help.DAL.Repositories
{
    static class CharacterEquipmentsRepository
    {
        public static ObservableCollection<EquipmentModel> GetEquipmentByCharacterId(int id)
        {
            ObservableCollection<EquipmentModel> result = new();
            using (var db = new AppDBContext()) {
                var characterEquipmentIds = db.CharacterEquipments.Where(e => e.CharacterId == id).ToList().ConvertAll(e => e.EquipmentId);
                if (characterEquipmentIds.Count == 0) {
                    return result;
                }
                var equipementCollection = db.Equipment.Where(e => characterEquipmentIds.Contains(e.Id)).ToList();
                foreach (var equipment in equipementCollection)
                {
                    result.Add(new EquipmentModel(equipment));
                }
            }
            return result;
        }
    }
}
