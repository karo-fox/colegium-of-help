using Avalonia.Collections;
using Collegium_of_Help.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;

namespace Collegium_of_Help.ViewModels;

public class MainViewModel : ViewModelBase
{
    private TabItemViewModel[] _tabItems;

    public TabItemViewModel[] TabItems
    {
        get => _tabItems;
        set => this.RaiseAndSetIfChanged(ref _tabItems, value);
    }
    public MainViewModel()
    {

        _tabItems =
        [
            new TabItemViewModel(iconPath: "/Assets/home.svg", content: new HomeView(), tabName: "Home"),
            new TabItemViewModel(
                iconPath: "/Assets/characters.svg",
                content: new CharactersView { DataContext = new CharactersViewModel() },
                tabName: "Characters"),
            new TabItemViewModel(iconPath: "/Assets/database.svg", content: new DatabaseView(), tabName: "Database")
        ];
    }
}
