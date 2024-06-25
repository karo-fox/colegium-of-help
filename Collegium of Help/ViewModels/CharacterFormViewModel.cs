using Avalonia.Markup.Xaml.MarkupExtensions;
using Collegium_of_Help.DAL.Repositories;
using Collegium_of_Help.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Input;

namespace Collegium_of_Help.ViewModels
{
    public class CharacterFormViewModel : ViewModelBase
    {
        private CharactersViewModel _host;
        private CharacterModel _character;
        private ICommand _backCommand;

        private string _formStatus = "";

        private string _name;
        private RaceModel? _race;
        private BackgroundModel? _background;
        private ClassModel? _class;
        private SubclassModel? _subclass;
        private int _level;
        private int _currentHp;
        private int _totalHp;

        private ObservableCollection<RaceModel> _races = RacesRepository.GetAll();
        private ObservableCollection<BackgroundModel> _backgrounds = BackgroundsRepository.GetAll();
        private ObservableCollection<ClassModel> _classes = ClassesRepository.GetAll();
        private ObservableCollection<SubclassModel>? _subclasses;

        private AbilityViewModel[] _abilities;

        private bool _isSubclassEnabled;
        private string _totalHpString;

        public CharacterFormViewModel(CharacterModel character, CharactersViewModel host)
        {
            _character = character;
            _host = host;
            _backCommand = _character.IsNew ? _host.GoToCharacterSelectionCommand : _host.GoToCharacterDetailsCommand;
            _name = _character.Name;
            _race = _character.Race;
            _background = _character.Background;
            _class = _character.Class;
            _subclasses = _class is not null ? SubclassesRepository.GetSubclassesByClassId(_class.Id) : [];
            _subclass = _character.Subclass;
            _level = _character.Level;
            _currentHp = _character.CurrentHp;
            _totalHp = _character.TotalHp;
            _isSubclassEnabled = Level >= 3;
            _totalHpString = $" / {TotalHp}";

            _abilities =
           [
               new AbilityViewModel("STR", _character.GetAbilityModifier(Ability.Strength), _character.GetAbilityScore(Ability.Strength), _character.SavingThrowProficiencies.GetValueOrDefault(Ability.Strength, false),
                [], _character.ProficiencyScore
                ),
                new AbilityViewModel("DEX", _character.GetAbilityModifier(Ability.Dexterity), _character.GetAbilityScore(Ability.Dexterity), _character.SavingThrowProficiencies.GetValueOrDefault(Ability.Dexterity, false),
                [], _character.ProficiencyScore
                ),
                new AbilityViewModel("CON", _character.GetAbilityModifier(Ability.Constitution), _character.GetAbilityScore(Ability.Constitution), _character.SavingThrowProficiencies.GetValueOrDefault(Ability.Constitution, false),
                [], _character.ProficiencyScore
                ),
                new AbilityViewModel("INT", _character.GetAbilityModifier(Ability.Intelligence), _character.GetAbilityScore(Ability.Intelligence), _character.SavingThrowProficiencies.GetValueOrDefault(Ability.Intelligence, false),
                [], _character.ProficiencyScore
                ),
                new AbilityViewModel("WIS", _character.GetAbilityModifier(Ability.Wisdom), _character.GetAbilityScore(Ability.Wisdom), _character.SavingThrowProficiencies.GetValueOrDefault(Ability.Wisdom, false),
                [], _character.ProficiencyScore
                ),
                new AbilityViewModel("CHA", _character.GetAbilityModifier(Ability.Charisma), _character.GetAbilityScore(Ability.Charisma), _character.SavingThrowProficiencies.GetValueOrDefault(Ability.Charisma, false),
                [], _character.ProficiencyScore
                )
           ];

            CanSave = this.WhenAnyValue(
                x => x.Class, x => x.Race, x => x.Background, x => x.Abilities, x => x.CurrentHp, x => x.Level,
                (@class, race, background, abilities, currentHp, level)
                    => @class is not null && race is not null && background is not null &&
                    abilities.All(a => a.Score is not null && 0 <= a.Score && a.Score <= 20) &&
                    0 <= currentHp && currentHp <= TotalHp && 0 <= level && level <= 20
            ); ;

            SaveCommand = ReactiveCommand.Create(Save, CanSave);
        }

        public CharactersViewModel Host { get => _host; }
        private IObservable<bool> CanSave;
        public ICommand BackCommand
        {
            get => _backCommand;
        }
        public ICommand SaveCommand { get; }
        private void Save()
        {
            _character.Name = this.Name;
            _character.Class = this.Class;
            _character.Subclass = this.Subclass;
            _character.Race = this.Race;
            _character.Background = this.Background;
            _character.TotalHp = this.TotalHp;
            _character.CurrentHp = this.CurrentHp ?? this.TotalHp;
            _character.Level = this.Level;
            _character.Strength = _abilities[0].Score ?? 10;
            _character.Dexterity = _abilities[1].Score ?? 10;
            _character.Constitution = _abilities[2].Score ?? 10;
            _character.Intelligence = _abilities[3].Score ?? 10;
            _character.Wisdom = _abilities[4].Score ?? 10;
            _character.Charisma = _abilities[5].Score ?? 10;
            _character.Proficiencies = this.Class.Proficiencies;
            _character.Langauges = this.Race.Languages;
            _character.WriteToDb();
            FormStatus = "Zmiany zapisano ";
        }

        public CharacterModel? BackCommandParameter
        {
            get => _character.IsNew ? null : _character;
        }

        //private IObservable<bool> CanSave =
        //    Class is not null && Race is not null && Background is not null && _abilities.All(a => a.Score is not null && 0 <= a.Score && a.Score <= 20)
        //    && CurrentHp <= TotalHp && CurrentHp >= 0 && 0 <= Level && Level <= 20;

        public string FormStatus
        {
            get => _formStatus;
            set => this.RaiseAndSetIfChanged(ref _formStatus, value);
        }

        [Required(ErrorMessage = "Pole wymagane")]
        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }
        [Required(ErrorMessage = "Pole wymagane")]
        public RaceModel? Race
        {
            get => _race;
            set => this.RaiseAndSetIfChanged(ref _race, value);
        }
        public ObservableCollection<RaceModel> Races
        {
            get => _races;
        }
        [Required(ErrorMessage = "Pole wymagane")]
        public BackgroundModel? Background
        {
            get => _background;
            set => this.RaiseAndSetIfChanged(ref _background, value);
        }
        public ObservableCollection<BackgroundModel> Backgrounds
        {
            get => _backgrounds;
        }
        [Required(ErrorMessage = "Pole wymagane")]
        public ClassModel? Class
        {
            get => _class;
            set
            {
                this.RaiseAndSetIfChanged(ref _class, value);
                Subclasses = SubclassesRepository.GetSubclassesByClassId(_class.Id);
            }
        }
        public ObservableCollection<ClassModel> Classes
        {
            get => _classes;
            set => this.RaiseAndSetIfChanged(ref _classes, value);
        }
        public SubclassModel? Subclass
        {
            get => _subclass;
            set => this.RaiseAndSetIfChanged(ref _subclass, value);
        }
        public ObservableCollection<SubclassModel> Subclasses
        {
            get => _class is not null ? SubclassesRepository.GetSubclassesByClassId(_class.Id) : [];
            set => this.RaiseAndSetIfChanged(ref _subclasses, value);
        }
        public bool IsSubclassEnabled
        {
            get => Level >= 3;
            set => this.RaiseAndSetIfChanged(ref _isSubclassEnabled, value);
        }
        [Range(1, 20, ErrorMessage ="Wartość musi być pomiędzy o a 20")]
        public int Level
        {
            get => _level;
            set
            {
                this.RaiseAndSetIfChanged(ref _level, value);
                IsSubclassEnabled = Level >= 3;
                TotalHp = _calculateTotalHp();
                CurrentHp = TotalHp;
            }
        }
        [Range(0, 300)]
        public int? CurrentHp
        {
            get => _currentHp;
            set
            {
                _currentHp = value ?? _totalHp;
                this.RaisePropertyChanged();

            }
        }
        public int TotalHp
        {
            get => _totalHp;
            set
            {
                this.RaiseAndSetIfChanged(ref _totalHp, value);
                TotalHpString = $" / {TotalHp}";
            }
        }
        public string TotalHpString
        {
            get => $" / {TotalHp}";
            set => this.RaiseAndSetIfChanged(ref _totalHpString, value);
        }
        public AbilityViewModel[] Abilities
        {
            get => _abilities;
        }

        private int _calculateTotalHp()
        {
            int hit_die = _character.Class?.HitDie ?? 0;
            int con = _abilities[2].Modifier;
            int result = (hit_die + Level * hit_die + 2 * Level + 2 * Level * con - 2) / 2;
            return result >= 0 ? result : 0;
        }
    }
}
