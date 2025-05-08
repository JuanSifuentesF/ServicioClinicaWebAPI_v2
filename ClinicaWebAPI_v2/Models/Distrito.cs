using System;
using System.Collections.Generic;

namespace ClinicaWebAPI_v2.Models;

public partial class Distrito
{
    public string Coddis { get; set; } = null!;

    public string? Nomdis { get; set; }

    public virtual ICollection<Medico> Medicos { get; set; } = new List<Medico>();

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
