using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class GroupEventDay
{
    public int id { get; set; }

    public int? groupEventId { get; set; }

    public int? dayId { get; set; }

    public virtual Day? day { get; set; }

    public virtual GroupEvent? groupEvent { get; set; }
}
