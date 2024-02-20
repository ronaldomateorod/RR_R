using System;
using System.Collections.Generic;

namespace RESCO_RRPAYROLL.Models;

public partial class Permiso
{
    public int Id { get; set; }

    public DateTime FechaInicio { get; set; }

    public string Motivo { get; set; } = null!;

    public DateTime FechaFinal { get; set; }

    public bool? Pagado { get; set; }

    public int IdAsistencia { get; set; }

    public DateTime FechaMcreacion { get; set; }

    public string CreadoPor { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? ModificadoPor { get; set; }

    public virtual Asistencia IdAsistenciaNavigation { get; set; } = null!;
}
