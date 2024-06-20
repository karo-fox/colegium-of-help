using System;
using System.Collections.Generic;

namespace Collegium_of_Help.Models.Entities;

public partial class Subclass
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Class { get; set; }

    public int SourceBook { get; set; }

    public virtual ICollection<Character> Characters { get; set; } = new List<Character>();

    public virtual Class ClassNavigation { get; set; } = null!;

    public virtual Source SourceBookNavigation { get; set; } = null!;
}
