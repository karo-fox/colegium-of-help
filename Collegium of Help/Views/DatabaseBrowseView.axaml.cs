using Avalonia.Controls;
using Collegium_of_Help.ViewModels;

namespace Collegium_of_Help.Views
{
    public partial class DatabaseBrowseView : UserControl
    {
        public DatabaseBrowseView()
        {
            DataContext = new TabItemViewModel[]
            {
                new TabItemViewModel(iconPath: "/Assets/classes.svg", content: new DatabaseBrowseClassesView(), tabName: "Klasy"),
                new TabItemViewModel(iconPath: "/Assets/races.svg", content: new DatabaseBrowseRacesView(), tabName: "Rasy"),
                new TabItemViewModel(iconPath: "/Assets/items.svg", content: new DatabaseBrowseItemsView(), tabName: "Przedmioty"),
                new TabItemViewModel(iconPath: "/Assets/backgrounds.svg", content: new DatabaseBrowseBackgroundsView(), tabName: "Pochodzenia"),
                new TabItemViewModel(iconPath: "/Assets/spells.svg", content: new DatabaseBrowseSpellsView(), tabName: "Czary"),
                new TabItemViewModel(iconPath: "/Assets/sources.svg", content: new DatabaseBrowseSourcesView(), tabName: "èrÛd≥a")
            };
            InitializeComponent();
        }
    }
}
