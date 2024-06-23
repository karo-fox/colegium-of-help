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

        public Dictionary<Ability, bool> SavingThrowProficiences
        {
            get => _savingThrowProficiencies;
        }
    }

}
