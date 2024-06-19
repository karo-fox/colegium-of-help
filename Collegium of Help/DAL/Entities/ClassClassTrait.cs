using System;
using System.Collections.Generic;

namespace Collegium_of_Help.Models.Entities;

public partial class ClassClassTrait
{
    public int ClassTraitId { get; set; }

    public int ClassId { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual ClassTrait ClassTrait { get; set; } = null!;
}
