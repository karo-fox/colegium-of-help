using System;
using System.Collections.Generic;

namespace Collegium_of_Help.Models.Entities;

public partial class Source
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Background> Backgrounds { get; set; } = new List<Background>();

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();

    public virtual ICollection<Race> Races { get; set; } = new List<Race>();

    public virtual ICollection<Spell> Spells { get; set; } = new List<Spell>();

    public virtual ICollection<Subclass> Subclasses { get; set; } = new List<Subclass>();

    public Source(int id, string name)
    {
        Id = id;
        Name = name;
    }
    public override string ToString()
    {
        return $"{Id}: {Name}";
    }
}
