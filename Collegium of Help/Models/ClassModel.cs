using Collegium_of_Help.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collegium_of_Help.Models
{
    public class ClassModel
    {
        private Class _class;
        private Dictionary<Ability, bool> _savingThrowProficiencies;

        public ClassModel(Class @class)
        {
            _class = @class;
            _savingThrowProficiencies = new Dictionary<Ability, bool>();
        }

        public string Name
        {
            get => _class.Name;
            set => _class.Name = value;
        }
        public int Id { get => _class.Id; }
        public int HitDie { get => _class.HitDie; }
        public string HitDieString { get => $"1d{_class.HitDie}"; }
        public string Proficiencies { get => $"{_class.SkillsProficienciesNum} z: {_class.SkillProficiencies};\nBiegłości w rzutach obronnych: {_class.SavingThrowProficiencies};\n{ _class.Proficiencies}"; }
        public int Money { get => _class.Money; }

        public Dictionary<Ability, bool> SavingThrowProficiences
        {
            get => _savingThrowProficiencies;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }

}
