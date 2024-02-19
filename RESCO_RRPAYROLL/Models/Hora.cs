using System;
using System.Collections.Generic;

namespace RESCO_RRPAYROLL.Models;

public partial class Hora
{
    public int Id { get; set; }

    public DateTime HorasInicio { get; set; }

    public DateTime? HoraFinal { get; set; }

    public int? IdAsistencia { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? CreadoPor { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? ModificadoPor { get; set; }

    public virtual Asistencia? IdAsistenciaNavigation { get; set; }
}
