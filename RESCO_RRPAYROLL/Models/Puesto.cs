using System;
using System.Collections.Generic;

namespace RESCO_RRPAYROLL.Models;

public partial class Puesto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? CreadoPor { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? ModificadoPor { get; set; }

    public virtual ICollection<EmpleadoProyecto> EmpleadoProyectos { get; set; } = new List<EmpleadoProyecto>();
}
