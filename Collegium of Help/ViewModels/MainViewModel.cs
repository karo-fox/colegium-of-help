using Avalonia.Collections;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;

namespace Collegium_of_Help.ViewModels;

public class MainViewModel : ViewModelBase
{
    private ViewModelBase _contentViewModel;
    public AvaloniaDictionary<string, ViewModelBase> views = new AvaloniaDictionary<string, ViewModelBase>();
    public ReactiveCommand<string, Unit> ChangeView { get; }
    public MainViewModel() 
    {
        views.Add("Home", new HomeViewModel());
        views.Add("Characters", new CharactersViewModel());
        _contentViewModel = views["Home"];
        ChangeView = ReactiveCommand.Create<string>(name =>
                {
                    ContentViewModel = views[name];
                });
    }

    public ViewModelBase ContentViewModel
    {
        get => _contentViewModel;
        private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
    }
}
