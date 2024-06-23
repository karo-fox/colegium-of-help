using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collegium_of_Help.Models;
using Collegium_of_Help.DAL.Repositories;

namespace Collegium_of_Help.ViewModels
{
    public class CharacterSelectionViewModel : ViewModelBase
    {
        private CharactersViewModel _host;
        public CharactersViewModel Host { get => _host; }
        public CharacterSelectionViewModel(CharactersViewModel host) => _host = host;

        private ObservableCollection<CharacterModel> _characters = CharactersRepository.GetAll();

        public ObservableCollection<CharacterModel> Characters
        {
            get => _characters;
            set => this.RaiseAndSetIfChanged(ref _characters, value);
        }
    }
}
