using System;
using System.Collections.Generic;

namespace Collegium_of_Help.Models.Entities;

public partial class Race
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Size { get; set; }

    public int Speed { get; set; }

    public string Langauges { get; set; } = null!;

    public int SourceBook { get; set; }

    public virtual ICollection<Character> Characters { get; set; } = new List<Character>();

    public virtual ICollection<RacialTrait> RacialTraits { get; set; } = new List<RacialTrait>();

    public virtual Source SourceBookNavigation { get; set; } = null!;

    public Race(int id, string name, string? size, int speed, string langauges, int sourceBook)
    {
        Id = id;
        Name = name;
        Size = size;
        Speed = speed;
        Langauges = langauges;
        SourceBook = sourceBook;
    }

    public override string ToString()
    {
        return $"{Name}";
    }
}
