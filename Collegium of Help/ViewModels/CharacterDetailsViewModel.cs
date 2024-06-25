using Collegium_of_Help.DAL.Repositories;
using Collegium_of_Help.Models;
using Collegium_of_Help.WDiscarded;
using Org.BouncyCastle.Asn1.Mozilla;
using ReactiveUI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Collegium_of_Help.ViewModels
{
    public class CharacterDetailsViewModel : ViewModelBase
    {
        private CharactersViewModel _host;
        public CharactersViewModel Host { get => _host; }

        private CharacterModel _character;

        private AbilityViewModel[] _abilities;
        private List<ProficiencyViewModel> _proficiencies;
        private List<ProficiencyViewModel> _languages;
        public CharacterDetailsViewModel(CharacterModel character, CharactersViewModel host)
        {
            _character = character;
            _host = host;
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
            _proficiencies = _character.Proficiencies.ToList().ConvertAll((item) => new ProficiencyViewModel(item));
            _languages = _character.Langauges.ToList().ConvertAll((item) => new ProficiencyViewModel(item));

        }

        public CharacterModel Character
        {
            get => _character;
        }

        public string Name
        {
            get => _character.Name;
        }
        public string RaceName
        {
            get => _character.Race.Name;
        }
        public string BackgroundName
        {
            get => _character.Background.Name;
        }
        public string ClassName
        {
            get => _character.Class.Name;
        }
        public string SubclassName
        {
            get => _character.Subclass?.Name ?? "";
        }
        public string Level
        {
            get => $"Level: {_character.Level}";
        }
        public string Hp
        {
            get => $"HP: {_character.CurrentHp} / {_character.TotalHp}";
        }
        public AbilityViewModel[] Abilities
        {
            get => _abilities;
        }
        public ObservableCollection<EquipmentModel> Equipment
        {
            get => _character.Equipment;
        }
        public List<ProficiencyViewModel> Proficiencies
        {
            get => _proficiencies;
        }
        public List<ProficiencyViewModel> Languages
        {
            get => _languages;
        }
    }
}
