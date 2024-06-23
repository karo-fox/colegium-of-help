using Avalonia.Controls;
using Collegium_of_Help.ViewModels;
namespace Collegium_of_Help.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        DataContext = new TabItemViewModel[]
        {
            new TabItemViewModel(iconPath: "/Assets/home.svg", content: new HomeView(), tabName: "Home"),
            new TabItemViewModel(iconPath: "/Assets/characters.svg", content: new CharactersView(), tabName: "Characters"),
            new TabItemViewModel(iconPath: "/Assets/database.svg", content: new DatabaseView(), tabName: "Database")
        };
        InitializeComponent();
    }
}
