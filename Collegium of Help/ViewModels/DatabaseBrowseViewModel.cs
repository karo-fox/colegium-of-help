using Collegium_of_Help.Models;
using Collegium_of_Help.Models.Entities;
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
        private DatabaseModel databaseModel = new DatabaseModel();
        public ObservableCollection<Source> Sources { get; set; }
        public DatabaseBrowseViewModel() 
        {
            Sources = new ObservableCollection<Source>(databaseModel.Sources);
        }

    }
}
