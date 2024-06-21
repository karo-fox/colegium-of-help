using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Collegium_of_Help.ViewModels;
using ReactiveUI;

namespace Collegium_of_Help.Views
{
    public partial class CharacterSelectionView : ReactiveUserControl<CharacterSelectionViewModel>
    {
        public CharacterSelectionView()
        {
            this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);
        }
    }
}
