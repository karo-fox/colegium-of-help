using System;
using System.Collections.Generic;

namespace Collegium_of_Help.Models.Entities;

public partial class BackgroundEquipment
{
    public int EquipmentId { get; set; }

    public int BackgroundId { get; set; }

    public virtual Background Background { get; set; } = null!;

    public virtual Equipment Equipment { get; set; } = null!;
}
