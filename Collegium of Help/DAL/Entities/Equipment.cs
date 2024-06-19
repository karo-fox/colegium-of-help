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
}
