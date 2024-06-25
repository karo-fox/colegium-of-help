using Collegium_of_Help.Models.Entities;
using Collegium_of_Help.Views;
using Collegium_of_Help.WDiscarded;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collegium_of_Help.ViewModels
{
    public class DatabaseBrowseViewModel : ViewModelBase
    {
        private TabItemViewModel[] _tabItems;
        public TabItemViewModel[] TabItems { get => _tabItems; }
        //private DatabaseModel databaseModel = new DatabaseModel();
        //public ObservableCollection<Source> Sources { get; set; }
        public DatabaseBrowseViewModel() 
        {
            //Sources = new ObservableCollection<Source>(databaseModel.Sources)
            _tabItems =
            [
                new TabItemViewModel(iconPath: "/Assets/classes.svg", content: new DatabaseBrowseClassesView(), tabName: "Klasy"),
                new TabItemViewModel(iconPath: "/Assets/races.svg", content: new DatabaseBrowseRacesView(), tabName: "Rasy"),
                new TabItemViewModel(iconPath: "/Assets/items.svg", content: new DatabaseBrowseItemsView(), tabName: "Przedmioty"),
                new TabItemViewModel(iconPath: "/Assets/backgrounds.svg", content: new DatabaseBrowseBackgroundsView(), tabName: "Pochodzenia"),
                new TabItemViewModel(iconPath: "/Assets/spells.svg", content: new DatabaseBrowseSpellsView(), tabName: "Czary"),
                new TabItemViewModel(iconPath: "/Assets/sources.svg", content: new DatabaseBrowseSourcesView(), tabName: "Źródła")
            ];
        }

    }
}
