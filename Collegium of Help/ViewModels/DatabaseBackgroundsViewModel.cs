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
        public ObservableCollection<Background> Backgrounds { get; set; }
        public int SelectedIndex { get => _selectedIndex; set 
            {
                this.RaiseAndSetIfChanged(ref _selectedIndex, value);
                BackgroundName = Backgrounds[_selectedIndex].Name;
                BackgroundProficiencies = Backgrounds[_selectedIndex].SkillProficiencies;
                BackgroundFeature = Backgrounds[_selectedIndex].Feature;
                BackgroundSource = Backgrounds[_selectedIndex].SourceBook;

            }
        }
        public string BackgroundName { get => _backgroundName; set => this.RaiseAndSetIfChanged(ref _backgroundName, value); }
        public string BackgroundProficiencies { get => _backgroundProficiencies; set => this.RaiseAndSetIfChanged(ref _backgroundProficiencies, value); }
        public string BackgroundFeature { get => _backgroundFeature; set => this.RaiseAndSetIfChanged(ref _backgroundFeature, value); }
        public int BackgroundSource { get => _backgroundSource; set => this.RaiseAndSetIfChanged(ref _backgroundSource, value); }

        #endregion

        #region Prywatne właściwości

        private int _selectedIndex = 0;
        private string _backgroundName;
        private string _backgroundProficiencies;
        private string _backgroundFeature;
        private int _backgroundSource;

        #endregion

        #region Metody
        public DatabaseBackgroundsViewModel() 
        { 
            Backgrounds = new ObservableCollection<Background>();
            Backgrounds.Add(new Background(1, "Artysta", "Zestaw do charakteryzacji", "Korzyść: Jestem znany", 1));
            Backgrounds.Add(new Background(2, "Pustelnik", "Kij", "Korzyść: Mam wiedzę", 1));
            SelectedIndex = 0;
        }

        #endregion
    }
}
