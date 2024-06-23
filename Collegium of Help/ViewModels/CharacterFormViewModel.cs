using Collegium_of_Help.Models;
using System.Windows.Input;

namespace Collegium_of_Help.ViewModels
{
    public class CharacterFormViewModel : ViewModelBase
    {
        private CharactersViewModel _host;
        private CharacterModel _character;
        private ICommand _backCommand;
        public CharacterFormViewModel(CharacterModel character, CharactersViewModel host)
        {
            _character = character;
            _host = host;
            _backCommand = _character.IsNew ? _host.GoToCharacterSelectionCommand : _host.GoToCharacterDetailsCommand;
        }

        public CharactersViewModel Host { get => _host; }
        public string Name
        {
            get => _character.Name;
        }
        public ICommand BackCommand
        {
            get => _backCommand;
        }
        public CharacterModel? BackCommandParameter
        {
            get => _character.IsNew ? null : _character;
        }
    }
}
