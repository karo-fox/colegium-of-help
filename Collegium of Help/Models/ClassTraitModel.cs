using Collegium_of_Help.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Collegium_of_Help.Models
{
    public class ClassTraitModel
    {
        private ClassTrait _classTrait;

        public ClassTraitModel(ClassTrait classTrait)
        {
            _classTrait = classTrait;
        }   

        public string Name { get => _classTrait.Name; }
        public string Description { get {
                string result = $"{_classTrait.Name}: ";
                if (_classTrait.Level == 1) result += "1st";
                else if (_classTrait.Level == 2) result += "2nd";
                else if (_classTrait.Level == 3) result += "3rd";
                else result += $"{_classTrait.Level}th";
                result += $" level ";
                if (_classTrait.Optional) result += "optional ";
                result += $"ability.\n{_classTrait.Description}";
                return result;
            } }

        public override string ToString()
        {
            return $"{_classTrait.Name}";
        }
    }
}
