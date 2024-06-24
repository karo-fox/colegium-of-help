using Collegium_of_Help.Models;
using Collegium_of_Help.DAL;
using Collegium_of_Help.Models.Entities;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collegium_of_Help.DAL.Repositories;

namespace Collegium_of_Help.ViewModels
{
    public class DatabaseSpellsViewModel : ViewModelBase
    {
        #region Publiczne właściwości
        public ObservableCollection<SpellModel> Spells { get => SpellsRepository.GetAll(); }
        public int SelectedSpell {  get => _selectedSpell; 
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedSpell, value);
                SpellName = Spells[_selectedSpell].Name;
                SpellSchool = $"Szkoła {Spells[_selectedSpell].School}";
                if (Spells[_selectedSpell].Level != "sztuczka") SpellLevel = $"{Spells[_selectedSpell].Level} krąg";
                else SpellLevel = Spells[_selectedSpell].Level;
                SpellCastingTime = $"Czas rzucania: {Spells[_selectedSpell].CastingTime}";
                SpellRange = $"Zasięg: {Spells[_selectedSpell].SpellRange}";
                SpellComponents = $"Komponenty: {Spells[_selectedSpell].Components}";
                SpellDuration = $"Czas trwania: {Spells[_selectedSpell].Duration}";
                SpellConcentration = Spells[_selectedSpell].Concentration;
                SpellSavingThrow = $"Wymaga rzutu obronnego: {Spells[_selectedSpell].SavingThrow}";
                SpellSource = SourcesRepository.GetById(Spells[_selectedSpell].SourceBook).Name;
            }
        }
        public string SpellName { get => _spellName; set => this.RaiseAndSetIfChanged(ref _spellName, value); }
        public string SpellSchool { get => _spellSchool; set => this.RaiseAndSetIfChanged(ref _spellSchool, value); }
        public string SpellLevel { get => _spellLevel; set => this.RaiseAndSetIfChanged(ref _spellLevel, value); }
        public string SpellCastingTime { get => _spellCastingTime; set => this.RaiseAndSetIfChanged(ref _spellCastingTime, value); }
        public string SpellRange { get => _spellRange; set => this.RaiseAndSetIfChanged(ref _spellRange, value); }
        public string SpellComponents { get => _spellComponents; set => this.RaiseAndSetIfChanged(ref _spellComponents, value); }
        public string SpellDuration { get => _spellDuration; set => this.RaiseAndSetIfChanged(ref _spellDuration, value); }
        public bool SpellConcentration { get => _spellConcentration; set => this.RaiseAndSetIfChanged(ref _spellConcentration, value); }
        public string SpellSavingThrow { get => _spellSavingThrow; set => this.RaiseAndSetIfChanged(ref _spellSavingThrow, value); }
        public string SpellSource { get => _spellSource; set => this.RaiseAndSetIfChanged(ref _spellSource, value); }

        #endregion

        #region Prywatne właściwości

        private int _selectedSpell = -1;
        private string _spellName = String.Empty;
        private string _spellSchool = String.Empty;
        private string _spellLevel = String.Empty;
        private string _spellCastingTime = String.Empty;
        private string _spellRange = String.Empty;
        private string _spellComponents = String.Empty;
        private string _spellDuration = String.Empty;
        private bool _spellConcentration = false;
        private string _spellSavingThrow = String.Empty;
        private string _spellSource;

        #endregion

        #region Metody
        public DatabaseSpellsViewModel()
        {
            
        }

        #endregion
    }
}
