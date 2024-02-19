using System;
using System.Collections.Generic;

namespace RESCO_RRPAYROLL.Models;

public partial class ActividadesAsignada
{
    public int Id { get; set; }

    public int IdActividad { get; set; }

    public int IdEmpleadoProyecto { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public int IdEstado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? CreadoPor { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? ModificadoPor { get; set; }

    public virtual Actividade IdActividadNavigation { get; set; } = null!;

    public virtual EmpleadoProyecto IdEmpleadoProyectoNavigation { get; set; } = null!;

    public virtual Estado IdEstadoNavigation { get; set; } = null!;
}
