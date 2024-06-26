﻿using System;
using System.Collections.Generic;

namespace Collegium_of_Help.Models.Entities;

public partial class ClassTrait
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string RefreshTime { get; set; } = null!;

    public int Level { get; set; }

    public bool Optional { get; set; }

    public override string ToString()
    {
        return $"{Name}";
    }
}
