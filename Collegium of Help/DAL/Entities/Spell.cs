using System;
using System.Collections.Generic;

namespace Collegium_of_Help.Models.Entities;

public partial class Spell
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Level { get; set; } = null!;

    public string School { get; set; } = null!;

    public string CastingTime { get; set; } = null!;

    public string SpellRange { get; set; } = null!;

    public string Components { get; set; } = null!;

    public string Duration { get; set; } = null!;

    public bool Concentration { get; set; }

    public string? SavingThrow { get; set; }

    public int SourceBook { get; set; }

    public virtual Source SourceBookNavigation { get; set; } = null!;

    public Spell(int id, string name, string level, string school, string castingTime, string spellRange, string components, string duration, bool concentration, string? savingThrow, int sourceBook)
    {
        Id = id;
        Name = name;
        Level = level;
        School = school;
        CastingTime = castingTime;
        SpellRange = spellRange;
        Components = components;
        Duration = duration;
        Concentration = concentration;
        SavingThrow = savingThrow;
        SourceBook = sourceBook;
    }

    public override string ToString()
    {
        return $"{Name}";
    }
}
