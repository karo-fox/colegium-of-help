﻿using Avalonia.Markup.Xaml.MarkupExtensions;
using Collegium_of_Help.DAL.Repositories;
using Collegium_of_Help.Models;
using ReactiveUI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Collegium_of_Help.ViewModels
{
    public class CharacterFormViewModel : ViewModelBase
    {
        private CharactersViewModel _host;
        private CharacterModel _character;
        private ICommand _backCommand;

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
        }

        public CharactersViewModel Host { get => _host; }
        public ICommand BackCommand
        {
            get => _backCommand;
        }
        public CharacterModel? BackCommandParameter
        {
            get => _character.IsNew ? null : _character;
        }
        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }
        public RaceModel? Race
        {
            get => _race;
            set => this.RaiseAndSetIfChanged(ref _race, value);
        }
        public ObservableCollection<RaceModel> Races
        {
            get => _races;
        }
        public BackgroundModel? Background
        {
            get => _background;
            set => this.RaiseAndSetIfChanged(ref _background, value);
        }
        public ObservableCollection<BackgroundModel> Backgrounds
        {
            get => _backgrounds;
        }
        public ClassModel? Class
        {
            get => _class;
            set => this.RaiseAndSetIfChanged(ref _class, value);
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
            get => _subclasses;
            set => this.RaiseAndSetIfChanged(ref _subclasses, value);
        }
        public bool IsSubclassEnabled
        {
            get => Level >= 3;
            set => this.RaiseAndSetIfChanged(ref _isSubclassEnabled, value);
        }
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
        public int CurrentHp
        {
            get => _currentHp;
            set => this.RaiseAndSetIfChanged(ref _currentHp, value);
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
            int con = _character.GetAbilityModifier(Ability.Constitution);
            return (hit_die + Level * hit_die + 2 * Level + 2 * Level * con - 2) / 2;
        }
    }
}