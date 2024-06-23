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
    public class DatabaseSpellsViewModel : ViewModelBase
    {
        #region Publiczne właściwości
        public ObservableCollection<Spell> Spells { get; set; }
        public int SelectedSpell {  get => _selectedSpell; 
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedSpell, value);
                SpellName = Spells[_selectedSpell].Name;
                SpellSchool = Spells[_selectedSpell].School;
                SpellLevel = Spells[_selectedSpell].Level;
                SpellCastingTime = Spells[_selectedSpell].CastingTime;
                SpellRange = Spells[_selectedSpell].SpellRange;
                SpellComponents = Spells[_selectedSpell].Components;
                SpellDuration = Spells[_selectedSpell].Duration;
                SpellConcentration = Spells[_selectedSpell].Concentration;
                SpellSavingThrow = Spells[_selectedSpell].SavingThrow;
                SpellSource = Spells[_selectedSpell].SourceBook.ToString();
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
        public string SpellSource { get => Spells[SelectedSpell].SourceBook.ToString(); set => this.RaiseAndSetIfChanged(ref _spellSource, value); }

        #endregion

        #region Prywatne właściwości

        private int _selectedSpell = 0;
        private string _spellName = String.Empty;
        private string _spellSchool = String.Empty;
        private string _spellLevel = String.Empty;
        private string _spellCastingTime = String.Empty;
        private string _spellRange = String.Empty;
        private string _spellComponents = String.Empty;
        private string _spellDuration = String.Empty;
        private bool _spellConcentration = false;
        private string _spellSavingThrow = String.Empty;
        private string _spellSource = String.Empty;

        #endregion

        #region Metody
        public DatabaseSpellsViewModel()
        {
            Spells = new ObservableCollection<Spell>();
            Spells.Add(new Spell(1, "Czar", "sztuczka", "Iluzji", "1 minuta", "18m", "W, S", "1 godzina", false, "ZRC", 1));
            Spells.Add(new Spell(2, "Czar2", "1", "Nekromancji", "1 akcja", "dotyk", "S", "natychmiastowe", true, null, 1));
            SelectedSpell = 0;
        }

        #endregion
    }
}
