using Collegium_of_Help.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collegium_of_Help.ViewModels
{
    public class DatabaseSourcesViewModel : ViewModelBase
    {
        public ObservableCollection<Source> Sources { get; set; }
        public DatabaseSourcesViewModel() 
        { 
            Sources = new ObservableCollection<Source>();
            Sources.Add(new Source(1, "PHB"));
            Sources.Add(new Source(2, "DMG"));
        }
    }
}
