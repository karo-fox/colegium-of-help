using System;
using System.Collections.Generic;

namespace Collegium_of_Help.Models.Entities;

public partial class ClassSpell
{
    public int SpellId { get; set; }

    public int ClassId { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual Spell Spell { get; set; } = null!;
}
