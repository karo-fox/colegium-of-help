namespace Collegium_of_Help.WDiscarded
{
    public class SkillViewModel
    {
        public string Name { get; set; }
        public bool Proficiency { get; set; }
        public int Modifier { get; set; }

        public SkillViewModel(string name, bool proficiency, int modifier)
        {
            Name = name;
            Proficiency = proficiency;
            Modifier = modifier;
        }
    }
}
