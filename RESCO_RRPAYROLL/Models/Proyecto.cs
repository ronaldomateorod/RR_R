using System;
using System.Collections.Generic;

namespace RESCO_RRPAYROLL.Models;

public partial class Proyecto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Cliente { get; set; } = null!;

    public string? Locacion { get; set; }

    public string? Descripcion { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFinal { get; set; }

    public int? IdEstado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? CreadoPor { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? ModificadoPor { get; set; }

    public virtual ICollection<Actividade> Actividades { get; set; } = new List<Actividade>();

    public virtual ICollection<EmpleadoProyecto> EmpleadoProyectos { get; set; } = new List<EmpleadoProyecto>();

    public virtual Estado? IdEstadoNavigation { get; set; } = null!;

    public virtual ICollection<Nomina> Nominas { get; set; } = new List<Nomina>();
}
