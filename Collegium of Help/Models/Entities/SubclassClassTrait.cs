using System;
using System.Collections.Generic;

namespace Collegium_of_Help.Models.Entities;

public partial class SubclassClassTrait
{
    public int ClassTraitId { get; set; }

    public int SubclassId { get; set; }

    public virtual ClassTrait ClassTrait { get; set; } = null!;

    public virtual Subclass Subclass { get; set; } = null!;
}
