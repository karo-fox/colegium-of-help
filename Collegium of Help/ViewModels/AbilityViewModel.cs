using Collegium_of_Help.WDiscarded;
using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;

namespace Collegium_of_Help.ViewModels
{
    public class AbilityViewModel : ViewModelBase
    {
        private int _savingThrowValue;
        private int _score = 10;
        private int _modifier;
        private string _modifierString;
        private int _proficiencyScore;
        private string _savingThrowString;
        public string Name { get; set; }
        public int Modifier
        {
            get => _modifier; set
            {
                this.RaiseAndSetIfChanged(ref _modifier, value);
                ModifierString = Modifier.ToString("+0;-#");
                _savingThrowValue = SavingThrowProficiency ? _proficiencyScore + Modifier : Modifier;
                SavingThrowString = "Saving Throw: " + _savingThrowValue.ToString("+0;-#");
            }
        }
        public string ModifierString
        {
            get => Modifier.ToString("+0;-#");
            set => this.RaiseAndSetIfChanged(ref _modifierString, value);
        }
        [Range(0, 20, ErrorMessage = "Umiejętność musi mieć wartość pomiędzy 0 a 20")]
        public int? Score
        {
            get => _score;
            set
            {
                _score = value ?? 10;
                this.RaisePropertyChanged();
                Modifier = ((int)Score / 2) - 5;
            }
        }
        public bool SavingThrowProficiency { get; set; }
        public string SavingThrowString
        {
            get => "Saving Throw: " + _savingThrowValue.ToString("+0;-#");
            set => this.RaiseAndSetIfChanged(ref _savingThrowString, value);
        }
        public SkillViewModel[] Skills { get; set; }

        public AbilityViewModel(string name, int modifier, int score, bool savingThrowProficiency, SkillViewModel[] skills, int proficiencyScore)
        {
            Name = name;
            SavingThrowProficiency = savingThrowProficiency;
            _proficiencyScore = proficiencyScore;
            Score = score;
            Skills = skills;
        }
    }
}
