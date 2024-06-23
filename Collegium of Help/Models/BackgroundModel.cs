using Collegium_of_Help.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collegium_of_Help.Models
{
    public class BackgroundModel
    {
        private Background _background;

        public BackgroundModel(Background background) => _background = background;

        public string Name
        {
            get => _background.Name;
        }

        public string SkillProficiencies { get => _background.SkillProficiencies; }
        public string Feature { get => _background.Feature; }
        public int SourceBook {  get => _background.SourceBook; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
