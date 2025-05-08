using System;
using System.Collections.Generic;

namespace ClinicaWebAPI_v2.Models;

public partial class Cita
{
    public int Nrocita { get; set; }

    public string? Codmed { get; set; }

    public string? Codpac { get; set; }

    public int? Tipo { get; set; }

    public decimal? Pago { get; set; }

    public DateTime? Fecha { get; set; }

    public int? Estado { get; set; }

    public string? Descrip { get; set; }

    public virtual Medico? CodmedNavigation { get; set; }

    public virtual Paciente? CodpacNavigation { get; set; }
}
