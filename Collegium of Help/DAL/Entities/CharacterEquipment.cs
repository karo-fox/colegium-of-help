using System;
using System.Collections.Generic;

namespace Collegium_of_Help.Models.Entities;

public partial class CharacterEquipment
{
    public int EquipmentId { get; set; }

    public int CharacterId { get; set; }

    public virtual Character Character { get; set; } = null!;

    public virtual Equipment Equipment { get; set; } = null!;
}
