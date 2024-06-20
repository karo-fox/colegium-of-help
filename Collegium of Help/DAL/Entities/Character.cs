using System;
using System.Collections.Generic;

namespace Collegium_of_Help.Models.Entities;

public partial class Character
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Race { get; set; }

    public int Background { get; set; }

    public int Class { get; set; }

    public int? Subclass { get; set; }

    public int Level { get; set; }

    public int Strength { get; set; }

    public int Dexterity { get; set; }

    public int Constitution { get; set; }

    public int Intelligence { get; set; }

    public int Wisdom { get; set; }

    public int Charisma { get; set; }

    public int CurrentHp { get; set; }

    public int TotalHp { get; set; }

    public string Proficiencies { get; set; } = null!;

    public string Langauges { get; set; } = null!;

    public int Equipment { get; set; }

    public string? SpellSlots { get; set; }

    public virtual Background BackgroundNavigation { get; set; } = null!;

    public virtual Class ClassNavigation { get; set; } = null!;

    public virtual Race RaceNavigation { get; set; } = null!;

    public virtual Subclass? SubclassNavigation { get; set; }
}
