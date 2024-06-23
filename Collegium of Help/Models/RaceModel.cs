using Collegium_of_Help.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collegium_of_Help.Models
{
    public class RaceModel
    {
        private Race _race;

        public RaceModel(Race race) => _race = race;

        public string Name
        {
            get => _race.Name;
            set => _race.Name = value;
        }

        public string Size { get => _race.Size; }
        public int Speed { get => _race.Speed; }
        public string Languages { get => _race.Langauges; }
        public int SourceBook { get => _race.SourceBook; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
