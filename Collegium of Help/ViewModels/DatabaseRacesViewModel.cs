using Collegium_of_Help.Models;
using Collegium_of_Help.Models.Entities;
using Collegium_of_Help.DAL.Repositories;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls.Templates;
using DynamicData;
using ExCSS;

namespace Collegium_of_Help.ViewModels
{
    public class DatabaseRacesViewModel : ViewModelBase
    {
        #region Publiczne właściwości
        public ObservableCollection<RaceModel> Races { get => RacesRepository.GetAll(); }
        public ObservableCollection<RacialTraitModel> RacialTraits { get; set;  }
        public int SelectedRace { get => _selectedRace; set {
                this.RaiseAndSetIfChanged(ref _selectedRace, value);
                RaceName = Races[_selectedRace].Name;
                Size = Races[_selectedRace].Size;
                Speed = Races[_selectedRace].Speed;
                Languages = Races[_selectedRace].Languages;
                RaceSource = SourcesRepository.GetById(Races[_selectedRace].SourceBook).Name;
                RacialTraits.Clear();
                RacialTraits.Add(RacialTraitRepository.GetTraitsByRaceId(_selectedRace+1));
                _selectedRaceAbility = -1;
                AbilityName = String.Empty;
                Description = String.Empty;
                Refresh = String.Empty;
            } }
        public int SelectedRaceAbility { get => _selectedRaceAbility; set
            {
                this.RaiseAndSetIfChanged(ref _selectedRaceAbility, value);
                if(_selectedRaceAbility >= 0)
                {
                    AbilityName = RacialTraits[_selectedRaceAbility].Name;
                    Description = RacialTraits[_selectedRaceAbility].Description;
                    Refresh = RacialTraits[_selectedRaceAbility].RefreshTime;
                }
            } }
        public string RaceName { get => _raceName; set => this.RaiseAndSetIfChanged(ref _raceName, value); }
        public string Size { get => _size; set => this.RaiseAndSetIfChanged(ref _size, value); }
        public int Speed { get => _speed; set => this.RaiseAndSetIfChanged(ref _speed, value); }
        public string Languages { get => _languages; set => this.RaiseAndSetIfChanged(ref _languages, value); }
        public string RaceSource { get => _source; set => this.RaiseAndSetIfChanged(ref _source, value); }
        public string AbilityName { get => _abilityName; set => this.RaiseAndSetIfChanged(ref _abilityName, value); }
        public string Description { get => _description; set => this.RaiseAndSetIfChanged(ref _description, value); }
        public string Refresh { get => _refresh; set => this.RaiseAndSetIfChanged(ref _refresh, value); }
        #endregion
        #region Prywatne właściwości
        private int _selectedRace = 0;
        private int _selectedRaceAbility = -1;
        private string _raceName = String.Empty;
        private string _size = String.Empty;
        private int _speed = 0;
        private string _languages = String.Empty;
        private string _source = String.Empty;
        private string _abilityName = String.Empty;
        private string _description = String.Empty;
        private string _refresh = String.Empty;
        #endregion
        #region Metody
        public DatabaseRacesViewModel()
        {
            RacialTraits = new ObservableCollection<RacialTraitModel>();
        }
        #endregion
    }
}
