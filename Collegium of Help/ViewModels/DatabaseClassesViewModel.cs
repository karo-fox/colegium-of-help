using Collegium_of_Help.Models.Entities;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Collegium_of_Help.ViewModels
{
    public class DatabaseClassesViewModel : ViewModelBase
    {
        #region Publiczne właściwości
        public ObservableCollection<Class> Classes { get; set; }
        public ObservableCollection<ClassTrait> Traits { get; set; }
        public ObservableCollection<Subclass> Subclasses { get; set; }
        public ObservableCollection<Spell> Spells { get; set; }
        public int SelectedClass { get => _selectedClass; set
            {
                this.RaiseAndSetIfChanged(ref _selectedClass, value);
            } }
        public int SelectedSubclass
        {
            get => _selectedSubclass; set
            {
                this.RaiseAndSetIfChanged(ref _selectedSubclass, value);
            }
        }
        public int SelectedAbility
        {
            get => _selectedAbility; set
            {
                this.RaiseAndSetIfChanged(ref _selectedAbility, value);
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
        private int _selectedClass = 0;
        private int _selectedSubclass = 0;
        private int _selectedAbility = 0;
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
            Classes = new ObservableCollection<Class>();
            Traits = new ObservableCollection<ClassTrait>();
            Subclasses = new ObservableCollection<Subclass>();
            Spells = new ObservableCollection<Spell>();
        }
        #endregion
    }
}
