using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.LogicalTree;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Collegium_of_Help.ViewModels;
using ReactiveUI;
using System;

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
