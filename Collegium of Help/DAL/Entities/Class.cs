using System;
using System.Collections.Generic;

namespace Collegium_of_Help.Models.Entities;

public partial class Class
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int HitDie { get; set; }

    public string Proficiencies { get; set; } = null!;

    public int SkillsProficienciesNum { get; set; }

    public string SkillProficiencies { get; set; } = null!;

    public string SavingThrowProficiencies { get; set; } = null!;

    public int Money { get; set; }

    public int SourceBook { get; set; }

    public virtual ICollection<Character> Characters { get; set; } = new List<Character>();

    public virtual Source SourceBookNavigation { get; set; } = null!;

    public virtual ICollection<Subclass> Subclasses { get; set; } = new List<Subclass>();

    public Class(int id, string name, int hitDie, string proficiencies, int skillsProficienciesNum, string skillProficiencies, string savingThrowProficiencies, int money, int sourceBook)
    {
        Id = id;
        Name = name;
        HitDie = hitDie;
        Proficiencies = proficiencies;
        SkillsProficienciesNum = skillsProficienciesNum;
        SkillProficiencies = skillProficiencies;
        SavingThrowProficiencies = savingThrowProficiencies;
        Money = money;
        SourceBook = sourceBook;
    }

    public override string ToString()
    {
        return $"{Name}";
    }
}
