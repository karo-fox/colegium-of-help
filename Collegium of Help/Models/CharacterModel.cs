using Collegium_of_Help.DAL.Repositories;
using Collegium_of_Help.Models.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Org.BouncyCastle.Asn1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private Character _character;

        private RaceModel _race;
        private BackgroundModel _background;
        private ClassModel _class;
        private SubclassModel? _subclass;

        private ObservableCollection<EquipmentModel> _equipment;

        private Dictionary<string, bool> _skillProficiencies;
        private string[] _proficiencies;
        private string[] _langauges;

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
            else
                _subclass = null;
            _equipment = CharacterEquipmentsRepository.GetEquipmentByCharacterId(_character.Id);
            _proficiencies = _character.Proficiencies.Split("; ");
            _langauges = _character.Langauges.Split("; ");
        }

        public string Name
        {
            get => _character.Name;
        }

        public ClassModel Class
        {
            get => _class;
        }

        public SubclassModel? Subclass
        {
            get => _subclass;
        }

        public RaceModel Race
        {
            get => _race;
        }

        public BackgroundModel Background
        {
            get => _background;
        }

        public int TotalHp
        {
            get => _character.TotalHp;
        }
        public int CurrentHp
        {
            get => _character.CurrentHp;
        }
        public int Level
        {
            get => _character.Level;
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
            get => _class.SavingThrowProficiences;
        }
        public string[] Proficiencies
        {
            get => _proficiencies;
        }
        public string[] Langauges
        {
            get => _langauges;
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
    }
}
