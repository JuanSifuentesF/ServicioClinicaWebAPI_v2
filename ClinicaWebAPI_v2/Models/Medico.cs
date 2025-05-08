using System;
using System.Collections.Generic;

namespace ClinicaWebAPI_v2.Models;

public partial class Medico
{
    public string Codmed { get; set; } = null!;

    public string? Codesp { get; set; }

    public string? Nommed { get; set; }

    public int? AnioColegio { get; set; }

    public string? Coddis { get; set; }

    public int? Estado { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual Distrito? CoddisNavigation { get; set; }

    public virtual Especialidad? CodespNavigation { get; set; }
}
