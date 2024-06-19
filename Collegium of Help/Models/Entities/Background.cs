﻿using System;
using System.Collections.Generic;

namespace Collegium_of_Help.Models.Entities;

public partial class Background
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? SkillProficiencies { get; set; }

    public string Feature { get; set; } = null!;

    public int SourceBook { get; set; }

    public virtual ICollection<Character> Characters { get; set; } = new List<Character>();

    public virtual Source SourceBookNavigation { get; set; } = null!;
}
