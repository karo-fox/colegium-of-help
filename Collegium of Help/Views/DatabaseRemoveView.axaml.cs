using Avalonia.Controls;
using Collegium_of_Help.ViewModels;

namespace Collegium_of_Help.Views
{
    public partial class DatabaseRemoveView : UserControl
    {
        public DatabaseRemoveView()
        {
            DataContext = new TabItemViewModel[]
            {
                new TabItemViewModel(iconPath: "/Assets/classes.svg", content: new DatabaseClassesView(), tabName: "Klasy"),
                new TabItemViewModel(iconPath: "/Assets/races.svg", content: new DatabaseRacesView(), tabName: "Rasy"),
                new TabItemViewModel(iconPath: "/Assets/items.svg", content: new DatabaseItemsView(), tabName: "Przedmioty"),
                new TabItemViewModel(iconPath: "/Assets/backgrounds.svg", content: new DatabaseBackgroundsView(), tabName: "Pochodzenia"),
                new TabItemViewModel(iconPath: "/Assets/spells.svg", content: new DatabaseSpellsView(), tabName: "Czary"),
                new TabItemViewModel(iconPath: "/Assets/sources.svg", content: new DatabaseSourcesView(), tabName: "èrÛd≥a")
            };
            InitializeComponent();
        }
    }
}
