using System;
using System.Collections.Generic;

namespace ClinicaWebAPI_v2.Models;

public partial class Paciente
{
    public string Codpac { get; set; } = null!;

    public string Nompac { get; set; } = null!;

    public string? Dnipac { get; set; }

    public string? TelCel { get; set; }

    public string? Dirpac { get; set; }

    public string? Coddis { get; set; }

    public int? Estado { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual Distrito? CoddisNavigation { get; set; }
}
