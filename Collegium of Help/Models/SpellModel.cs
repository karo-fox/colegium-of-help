using Collegium_of_Help.DAL.Repositories;
using Collegium_of_Help.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collegium_of_Help.Models
{
    public class SpellModel
    {
        private Spell _spell;
        public SpellModel(Spell spell) => _spell = spell;

        public String Name { get => _spell.Name; }
        public String Level { get => _spell.Level; }
        public String School { get => _spell.School; }
        public String CastingTime { get => _spell.CastingTime; }
        public String SpellRange { get => _spell.SpellRange; }
        public String Components { get => _spell.Components; }
        public String Duration { get => _spell.Duration; }
        public bool Concentration { get => _spell.Concentration; }
        public String SavingThrow { get => _spell.SavingThrow; }
        public int SourceBook { get => _spell.SourceBook; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
