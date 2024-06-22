using Avalonia.Controls;
using ReactiveUI;
using Collegium_of_Help.Views;
using System.Windows.Input;
using Collegium_of_Help.Models;

namespace Collegium_of_Help.ViewModels
{
    public class CharactersViewModel : ViewModelBase
    {
        private CharacterSelectionViewModel _characterSelectionViewModel;

        private ViewModelBase _content;
        public ViewModelBase Content
        {
            get => _content;
            set => this.RaiseAndSetIfChanged(ref _content, value);
        }
        public CharactersViewModel() 
        {
            _characterSelectionViewModel = new CharacterSelectionViewModel(this);
            Content = _characterSelectionViewModel;
            GoToCharacterDetailsCommand = ReactiveCommand.Create<CharacterModel>(GoToCharacterDetails);
            GoToCharacterSelectionCommand = ReactiveCommand.Create(GoToCharacterSelection);
        }

        public ICommand GoToCharacterDetailsCommand { get; }
        private void GoToCharacterDetails(CharacterModel character)
        {
            Content = new CharacterDetailsViewModel(character, this);
        }

        public ICommand GoToCharacterSelectionCommand { get; }
        private void GoToCharacterSelection()
        {
            Content = _characterSelectionViewModel;
        }
    }
}
