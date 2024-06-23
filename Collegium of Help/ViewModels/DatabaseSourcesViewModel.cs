using Collegium_of_Help.DAL.Repositories;
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
    public class DatabaseSourcesViewModel : ViewModelBase
    {
        public ObservableCollection<SourceModel> Sources { get => SourcesRepository.GetAll(); }
        public DatabaseSourcesViewModel() 
        { 

        }
    }
}
