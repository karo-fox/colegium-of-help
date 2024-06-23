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

        public string Description { get => _equipment.Description; }
        public string Rarity {  get => _equipment.Rarity; }
        public float Weight { get => _equipment.Weight; }
        public string Cost { get => _equipment.Cost; }
        public bool Magic { get => _equipment.Magic; }
        public string Alignment { get => _equipment.Alignment; }
        public int SourceBook {  get => _equipment.SourceBook; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
