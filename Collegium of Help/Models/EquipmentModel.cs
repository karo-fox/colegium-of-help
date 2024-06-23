using Collegium_of_Help.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collegium_of_Help.Models
{
    public class EquipmentModel
    {
        private Equipment _equipment;

        public EquipmentModel(Equipment equipment)
        {
            _equipment = equipment;
        }
        public string Name
        {
            get => _equipment.Name;
        }
    }
}
