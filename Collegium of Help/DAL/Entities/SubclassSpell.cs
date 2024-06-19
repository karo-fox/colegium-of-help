using System;
using System.Collections.Generic;

namespace Collegium_of_Help.Models.Entities;

public partial class SubclassSpell
{
    public int SpellId { get; set; }

    public int SubclassId { get; set; }

    public virtual Spell Spell { get; set; } = null!;

    public virtual Subclass Subclass { get; set; } = null!;
}
