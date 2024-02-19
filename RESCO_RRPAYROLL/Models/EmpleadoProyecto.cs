using System;
using System.Collections.Generic;

namespace RESCO_RRPAYROLL.Models;

public partial class EmpleadoProyecto
{
    public int Id { get; set; }

    public int IdPuesto { get; set; }

    public int IdProyecto { get; set; }

    public int IdEmpleado { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string? CreadoPor { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? ModificadoPor { get; set; }

    public int? Horas { get; set; }

    public double? PagoHoras { get; set; }

    public virtual ICollection<ActividadesAsignada> ActividadesAsignada { get; set; } = new List<ActividadesAsignada>();

    public virtual ICollection<Asistencia> Asistencia { get; set; } = new List<Asistencia>();

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    public virtual Proyecto IdProyectoNavigation { get; set; } = null!;

    public virtual Puesto IdPuestoNavigation { get; set; } = null!;
}
