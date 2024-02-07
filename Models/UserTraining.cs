using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class UserTraining
{
    public int id { get; set; }

    public int? accountId { get; set; }

    public int? trainingId { get; set; }

    public int? dayId { get; set; }

    public DateTime? date { get; set; }

    public virtual Account? account { get; set; }

    public virtual Day? day { get; set; }

    public virtual Training? training { get; set; }
}
