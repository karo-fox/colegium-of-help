using Avalonia.Controls;
using ReactiveUI;
using Collegium_of_Help.Views;

namespace Collegium_of_Help.ViewModels
{
    public class CharactersViewModel : ViewModelBase
    {
        private CharacterSelectionViewModel _characterSelectionViewModel = new CharacterSelectionViewModel();

        private ViewModelBase _content;
        public ViewModelBase Content
        {
            get => _content;
            set => this.RaiseAndSetIfChanged(ref _content, value);
        }
        public CharactersViewModel() 
        {
            Content = _characterSelectionViewModel;
        }
    }
}
