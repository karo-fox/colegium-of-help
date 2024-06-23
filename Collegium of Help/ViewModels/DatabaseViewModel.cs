using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collegium_of_Help.Models;
using Collegium_of_Help.Models.Entities;

namespace Collegium_of_Help.ViewModels
{
    public class DatabaseViewModel : ViewModelBase
    {
        private DatabaseModel _databaseModel = new DatabaseModel();
        public ObservableCollection<Source> Sources { get; set; }
        public DatabaseViewModel()
        {
            Sources = new ObservableCollection<Source>(_databaseModel.Sources);
        }
    }
}
