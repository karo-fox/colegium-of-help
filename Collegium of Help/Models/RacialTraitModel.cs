using Collegium_of_Help.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Collegium_of_Help.Models
{
    public class RacialTraitModel
    {
        private RacialTrait _racialTrait;

        public RacialTraitModel(RacialTrait racialTrait)
        {
            _racialTrait = racialTrait;
        }

        public string Name { get => _racialTrait.Name; }
        public string Description {  get => _racialTrait.Description; }
        public string RefreshTime { get =>  _racialTrait.RefreshTime; }
        public int Race {  get => _racialTrait.Race; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
