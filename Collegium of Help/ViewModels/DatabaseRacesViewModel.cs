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
    public class DatabaseRacesViewModel : MainViewModel
    {
        #region Publiczne właściwości
        public ObservableCollection<Race> Races { get; set; }
        public ObservableCollection<RacialTrait> RacialTraits { get; set; }
        public int SelectedRace { get => _selectedRace; set {
                this.RaiseAndSetIfChanged(ref _selectedRace, value);
                RaceName = Races[_selectedRace].Name;
                Size = Races[_selectedRace].Size;
                Speed = Races[_selectedRace].Speed;
                Languages = Races[_selectedRace].Langauges;
                RaceSource = Races[_selectedRace].SourceBook;
                if(_selectedRace == 0)
                {
                    RacialTraits.Clear();
                    RacialTraits.Add(new RacialTrait(1, "Wszechstronność", "opis", "Brak", 0));
                }
                else
                {
                    RacialTraits.Clear();
                    RacialTraits.Add(new RacialTrait(1, "Elfia medytacja", "opis", "Brak", 1));
                }
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
        public int RaceSource { get => _source; set => this.RaiseAndSetIfChanged(ref _source, value); }
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
        private int _source = 0;
        private string _abilityName = String.Empty;
        private string _description = String.Empty;
        private string _refresh = String.Empty;
        #endregion
        #region Metody
        public DatabaseRacesViewModel()
        {
            Races = new ObservableCollection<Race>();
            Races.Add(new Race(1, "Człowiek", "Średni", 9, "Wspólny", 1));
            Races.Add(new Race(2, "Elf", "Średni", 12, "Elfi", 1));
            RacialTraits = new ObservableCollection<RacialTrait>();
        }
        #endregion
    }
}
