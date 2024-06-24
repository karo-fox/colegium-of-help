using Collegium_of_Help.DAL.Repositories;
using Collegium_of_Help.Models;
using Collegium_of_Help.Models.Entities;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collegium_of_Help.ViewModels
{
    public class DatabaseBackgroundsViewModel : ViewModelBase
    {
        #region Publiczne właściwości
        public ObservableCollection<BackgroundModel> Backgrounds { get => BackgroundsRepository.GetAll(); }
        public int SelectedIndex { get => _selectedIndex; set 
            {
                this.RaiseAndSetIfChanged(ref _selectedIndex, value);
                BackgroundName = Backgrounds[_selectedIndex].Name;
                BackgroundProficiencies = $"Biegłości: {Backgrounds[_selectedIndex].SkillProficiencies}";
                BackgroundFeature = $"Korzyść: {Backgrounds[_selectedIndex].Feature}";
                BackgroundSource = SourcesRepository.GetById(Backgrounds[_selectedIndex].SourceBook).Name;

            }
        }
        public string BackgroundName { get => _backgroundName; set => this.RaiseAndSetIfChanged(ref _backgroundName, value); }
        public string BackgroundProficiencies { get => _backgroundProficiencies; set => this.RaiseAndSetIfChanged(ref _backgroundProficiencies, value); }
        public string BackgroundFeature { get => _backgroundFeature; set => this.RaiseAndSetIfChanged(ref _backgroundFeature, value); }
        public string BackgroundSource { get => _backgroundSource; set => this.RaiseAndSetIfChanged(ref _backgroundSource, value); }

        #endregion

        #region Prywatne właściwości

        private int _selectedIndex = -1;
        private string _backgroundName;
        private string _backgroundProficiencies;
        private string _backgroundFeature;
        private string _backgroundSource;

        #endregion

        #region Metody
        public DatabaseBackgroundsViewModel() 
        { 
        }

        #endregion
    }
}
