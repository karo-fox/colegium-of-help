using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collegium_of_Help.Models;
using Collegium_of_Help.DAL.Repositories;
using System.Windows.Input;

namespace Collegium_of_Help.ViewModels
{
    public class CharacterSelectionViewModel : ViewModelBase
    {
        private CharactersViewModel _host;
        public CharactersViewModel Host { get => _host; }
        public CharacterSelectionViewModel(CharactersViewModel host)
        {
            _host = host;
            RemoveCommand = ReactiveCommand.Create<CharacterModel>(Remove);
        }

        private ObservableCollection<CharacterModel> _characters = CharactersRepository.GetAll();

        public ObservableCollection<CharacterModel> Characters
        {
            get => CharactersRepository.GetAll();
            set => this.RaiseAndSetIfChanged(ref _characters, value);
        }

        public ICommand RemoveCommand { get; }
        private void Remove(CharacterModel character)
        {
            CharactersRepository.Remove(character);
            Characters = CharactersRepository.GetAll();
        }
    }
}
