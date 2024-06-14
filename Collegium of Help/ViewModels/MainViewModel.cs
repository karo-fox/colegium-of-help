using ReactiveUI;

namespace Collegium_of_Help.ViewModels;

public class MainViewModel : ViewModelBase
{
    private ViewModelBase _contentViewModel;
    public MainViewModel() 
    { 
        Home = new HomeViewModel();
        Characters = new CharactersViewModel();
        _contentViewModel = Home;
    }

    public HomeViewModel Home { get; set; }
    public CharactersViewModel Characters { get; set; }
    public ViewModelBase ContentViewModel
    {
        get => _contentViewModel;
        private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
    }

    public void ChangeToHome()
    {
        ContentViewModel = new HomeViewModel();
    }
    public void ChangeToCharacters()
    {
        ContentViewModel = new CharactersViewModel();
    }
}
