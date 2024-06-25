using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collegium_of_Help.Models.Entities;
using Collegium_of_Help.Views;
using Collegium_of_Help.WDiscarded;

namespace Collegium_of_Help.ViewModels
{
    public class DatabaseViewModel : ViewModelBase
    {
        private TabItemViewModel[] _tabItems;
        public TabItemViewModel[] TabItems { get => _tabItems; }
        //private DatabaseModel _databaseModel = new DatabaseModel();
        //public ObservableCollection<Source> Sources { get; set; }
        public DatabaseViewModel()
        {
            //Sources = new ObservableCollection<Source>(_databaseModel.Sources);
            _tabItems =
            [
                new TabItemViewModel(iconPath: "/Assets/home.svg", content: new DatabaseBrowseView { DataContext = new DatabaseBrowseViewModel() }, tabName: "Przeglądaj"),
                //new TabItemViewModel(iconPath: "/Assets/database.svg", content: new DatabaseAddView(), tabName: "Dodaj"),
                //new TabItemViewModel(iconPath: "/Assets/home.svg", content: new DatabaseModifyView(), tabName: "Modyfikuj"),
                //new TabItemViewModel(iconPath: "/Assets/database.svg", content: new DatabaseRemoveView(), tabName: "Usuń")
            ];
        }
    }
}
