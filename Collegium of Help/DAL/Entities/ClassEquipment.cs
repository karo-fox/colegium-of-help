using System;
using System.Collections.Generic;

namespace Collegium_of_Help.Models.Entities;

public partial class ClassEquipment
{
    public int EquipmentId { get; set; }

    public int ClassId { get; set; }

    public int Slot { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual Equipment Equipment { get; set; } = null!;
}
