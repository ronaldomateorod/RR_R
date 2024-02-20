using System;
using System.Collections.Generic;

namespace RESCO_RRPAYROLL.Models;

public partial class Licencia
{
    public int Id { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public string Motivo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int IdEmpleado { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string CreadoPor { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? ModificadoPor { get; set; }

    public bool? Pagado { get; set; }

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
}
