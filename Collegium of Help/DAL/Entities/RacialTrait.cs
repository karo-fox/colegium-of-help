using System;
using System.Collections.Generic;

namespace Collegium_of_Help.Models.Entities;

public partial class RacialTrait
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string RefreshTime { get; set; } = null!;

    public int Race { get; set; }

    public virtual Race RaceNavigation { get; set; } = null!;
}
