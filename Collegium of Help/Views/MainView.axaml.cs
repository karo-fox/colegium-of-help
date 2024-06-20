﻿using Avalonia.Controls;
using Collegium_of_Help.ViewModels;
namespace Collegium_of_Help.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        DataContext = new TabItemViewModel[]
        {
            new TabItemViewModel(iconPath: "/Assets/home.svg", content: new HomeView()),
            new TabItemViewModel(iconPath: "/Assets/characters.svg", content: new CharactersView()),
        };
        InitializeComponent();
    }
}
