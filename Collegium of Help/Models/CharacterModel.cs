using Collegium_of_Help.DAL.Repositories;
using Collegium_of_Help.Models.Entities;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Collegium_of_Help.Models
{
    public enum Ability
    {
        Strength,
        Dexterity,
        Constitution,
        Intelligence,
        Wisdom,
        Charisma
    }
    public class CharacterModel
    {
        private Character _character = new Character();

        private RaceModel? _race = null;
        private BackgroundModel? _background = null;
        private ClassModel? _class = null;
        private SubclassModel? _subclass = null;

        private ObservableCollection<EquipmentModel> _equipment = [];

        private Dictionary<string, bool> _skillProficiencies = new Dictionary<string, bool>();
        private string[] _proficiencies = [];
        private string[] _langauges = [];

        private bool _isNew = true;

        public CharacterModel(Character character)
        {
            _character = character;
            _race = RacesRepository.GetById(_character.Race);
            _background = BackgroundsRepository.GetById(_character.Background);
            _class = ClassesRepository.GetById(_character.Class);
            if (_character.Subclass != null)
            {
                _subclass = SubclassesRepository.GetById((int)_character.Subclass);
            }
            _equipment = CharacterEquipmentsRepository.GetEquipmentByCharacterId(_character.Id);
            _proficiencies = _character.Proficiencies.Split(";");
            _langauges = _character.Langauges.Split(";");
            _isNew = false;
        }

        public CharacterModel() { }

        public void WriteToDb()
        {
            CharactersRepository.CreateOrUpdate(this);
            _isNew = false;
        }
        public int? Id { get => _character.Id; }

        public string Name
        {
            get => _character.Name;
            set => _character.Name = value;
        }

        public ClassModel? Class
        {
            get => _class;
            set => _class = value;
        }

        public SubclassModel? Subclass
        {
            get => _subclass;
            set => _subclass = value;
        }

        public RaceModel? Race
        {
            get => _race;
            set => _race = value;
        }

        public BackgroundModel? Background
        {
            get => _background;
            set => _background  = value;
        }

        public int TotalHp
        {
            get => _character.TotalHp;
            set => _character.TotalHp = value;
        }
        public int CurrentHp
        {
            get => _character.CurrentHp;
            set => _character.CurrentHp = value;
        }
        public int Level
        {
            get => _character.Level;
            set => _character.Level = value;
        }
        public int ProficiencyScore
        {
            get => (int)((Level - 1) / 4) + 2;
        }
        public ObservableCollection<EquipmentModel> Equipment
        {
            get => _equipment;
        }
        public Dictionary<Ability, bool> SavingThrowProficiencies
        {
            get => _class?.SavingThrowProficiences ?? new Dictionary<Ability, bool>();
        }
        public string[] Proficiencies
        {
            get => _proficiencies;
            set => _proficiencies = value;
        }
        public string[] Langauges
        {
            get => _langauges;
            set => _langauges = value;
        }
        public bool IsNew
        {
            get => _isNew;
        }
        public int Strength
        {
            get => _character.Strength;
            set => _character.Strength = value;
        }
        public int Dexterity
        {
            get => _character.Dexterity;
            set => _character.Dexterity = value;
        }
        public int Constitution
        {
            get => _character.Constitution;
            set => _character.Constitution = value;
        }
        public int Intelligence
        {
            get => _character.Intelligence;
            set => _character.Intelligence = value;
        }
        public int Wisdom
        {
            get => _character.Wisdom;
            set => _character.Wisdom = value;
        }
        public int Charisma
        {
            get => _character.Charisma;
            set => _character.Charisma = value;
        }
        public int GetAbilityScore(Ability ability)
        {
            return ability switch
            {
                Ability.Strength => _character.Strength,
                Ability.Dexterity => _character.Dexterity,
                Ability.Constitution => _character.Constitution,
                Ability.Intelligence => _character.Intelligence,
                Ability.Wisdom => _character.Wisdom,
                Ability.Charisma => _character.Charisma,
                _ => throw new ArgumentOutOfRangeException(nameof(ability)),
            };
        }

        public int GetAbilityModifier(Ability ability)
        {
            return (GetAbilityScore(ability) / 2) - 5;
        }
        public int GetSkillModifier(Ability ability, bool proficiency)
        {
            return proficiency ? GetAbilityModifier(ability) + ProficiencyScore : GetAbilityModifier(ability);
        }

        public int CalculateTotalHp(int? level, int? con)
        {
            if (level == null) { level = Level; }
            if (con == null) { con = GetAbilityModifier(Ability.Constitution); }
            int hit_die = _class?.HitDie ?? 0;
            int result = (hit_die + (int)level * hit_die + 2 * (int)level + 2 * (int)level * (int)con - 2) / 2;
            return result >= 0 ? result : 0;
        }
    }
}
