using Collegium_of_Help.DAL.Repositories;
using Collegium_of_Help.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collegium_of_Help.Models
{
    public class CharacterModel
    {
        private Character _character;

        private RaceModel _race;
        private ClassModel _class;

        public CharacterModel(Character character)
        {
            _character = character;
            _race = RacesRepository.GetById(_character.Race);
            _class = ClassesRepository.GetById(_character.Class);
        }

        public string Name
        {
            get => _character.Name;
        }

        public string ClassName
        {
            get => _class.Name;
        }

        public string RaceName
        {
            get => _race.Name;
        }
    }
}
