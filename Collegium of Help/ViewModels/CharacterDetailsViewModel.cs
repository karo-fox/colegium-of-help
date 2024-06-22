using Collegium_of_Help.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collegium_of_Help.ViewModels
{
    public class CharacterDetailsViewModel : ViewModelBase
    {
        private CharactersViewModel _host;
        public CharactersViewModel Host { get => _host; }

        private CharacterModel _character;
        public CharacterDetailsViewModel(CharacterModel character, CharactersViewModel host)
        {
            _character = character;
            _host = host;
        }

        public string Name
        {
            get => _character.Name;
        }
    }
}
