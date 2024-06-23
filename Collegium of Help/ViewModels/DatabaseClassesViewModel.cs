using Collegium_of_Help.Models;
using Collegium_of_Help.Models.Entities;
using Collegium_of_Help.DAL.Repositories;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using DynamicData;

namespace Collegium_of_Help.ViewModels
{
    public class DatabaseClassesViewModel : ViewModelBase
    {
        #region Publiczne właściwości
        public ObservableCollection<ClassModel> Classes { get => ClassesRepository.GetAll(); }
        public ObservableCollection<ClassTraitModel> Traits { get; set; }
        public ObservableCollection<SubclassModel> Subclasses { get; set; }
        public ObservableCollection<SpellModel> Spells { get; set; }
        public int SelectedClass { get => _selectedClass; set
            {
                this.RaiseAndSetIfChanged(ref _selectedClass, value);
                ClassName = Classes[_selectedClass].Name;
                HitDie = Classes[_selectedClass].HitDieString;
                Proficiencies = Classes[_selectedClass].ProficienciesString;
                Money = Classes[_selectedClass].Money;
                Subclasses.Clear();
                Subclasses.Add(SubclassesRepository.GetSubclassesByClassId(Classes[_selectedClass].Id));
                Traits.Clear();
                Traits.Add(ClassTraitsRepository.GetTraitsByClassId(Classes[_selectedClass].Id));
                Spells.Clear();
                Spells.Add(SpellsRepository.GetSpellsByClassId(Classes[_selectedClass].Id));
                _selectedSubclass = -1;
                SubclassName = String.Empty;
                _selectedAbility = -1;
                AbilityName = String.Empty;
                Description = String.Empty;
            } }
        public int SelectedSubclass
        {
            get => _selectedSubclass; set
            {
                this.RaiseAndSetIfChanged(ref _selectedSubclass, value);
                if (_selectedSubclass >= 0)
                {
                    SubclassName = Subclasses[_selectedSubclass].Name;
                    Traits.Clear();
                    Traits.Add(ClassTraitsRepository.GetTraitsByClassId(Classes[_selectedClass].Id));
                    Traits.Add(ClassTraitsRepository.GetTraitsBySubclassId(Subclasses[_selectedSubclass].Id));
                    Spells.Clear();
                    Spells.Add(SpellsRepository.GetSpellsByClassId(Classes[_selectedClass].Id));
                    Spells.Add(SpellsRepository.GetSpellsBySubclassId(Subclasses[_selectedSubclass].Id));
                    _selectedAbility = -1;
                    AbilityName = String.Empty;
                    Description = String.Empty;
                }
            }
        }
        public int SelectedAbility
        {
            get => _selectedAbility; set
            {
                this.RaiseAndSetIfChanged(ref _selectedAbility, value);
                if (_selectedAbility >= 0)
                {
                    AbilityName = Traits[_selectedAbility].Name;
                    Description = Traits[_selectedAbility].Description;
                }   
            }
        }
        public string ClassName { get => _className; set => this.RaiseAndSetIfChanged(ref _className, value); }
        public string HitDie { get => _hitDie; set => this.RaiseAndSetIfChanged(ref _hitDie, value); }
        public string Proficiencies { get => _proficiencies; set => this.RaiseAndSetIfChanged(ref _proficiencies, value); }
        public int Money { get => _money; set => this.RaiseAndSetIfChanged(ref _money, value); }
        public string SubclassName { get => _subclassName; set => this.RaiseAndSetIfChanged(ref _subclassName, value); }
        public string AbilityName { get => _abilityName; set => this.RaiseAndSetIfChanged(ref _abilityName, value); }
        public string Description { get => _description; set => this.RaiseAndSetIfChanged(ref _description, value); }
        #endregion
        #region Prywatne właściwości
        private int _selectedClass = -1;
        private int _selectedSubclass = -1;
        private int _selectedAbility = -1;
        private string _className = String.Empty;
        private string _hitDie = String.Empty;
        private string _proficiencies = String.Empty;
        private string _savingThrows = String.Empty;
        private int _money = 0;
        private string _subclassName = String.Empty;
        private string _abilityName = String.Empty;
        private string _description = String.Empty;
        private string _refresh = String.Empty;
        private int _level = 0;
        private bool _optional = false;
        #endregion
        #region Metody
        public DatabaseClassesViewModel() 
        { 
            Traits = new ObservableCollection<ClassTraitModel>();
            Subclasses = new ObservableCollection<SubclassModel>();
            Spells = new ObservableCollection<SpellModel>();
        }
        #endregion
    }
}
