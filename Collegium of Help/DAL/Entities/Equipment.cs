using System;
using System.Collections.Generic;

namespace Collegium_of_Help.Models.Entities;

public partial class Equipment
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Rarity { get; set; } = null!;

    public float Weight { get; set; }

    public string Cost { get; set; } = null!;

    public bool Magic { get; set; }

    public string? Alignment { get; set; }

    public int SourceBook { get; set; }

    public virtual Source SourceBookNavigation { get; set; } = null!;

    public Equipment(int id, string name, string description, string rarity, float weight, string cost, bool magic, string? alignment, int sourceBook)
    {
        Id = id;
        Name = name;
        Description = description;
        Rarity = rarity;
        Weight = weight;
        Cost = cost;
        Magic = magic;
        Alignment = alignment;
        SourceBook = sourceBook;
    }

    public override string ToString()
    {
        return $"{Name}";
    }
}
