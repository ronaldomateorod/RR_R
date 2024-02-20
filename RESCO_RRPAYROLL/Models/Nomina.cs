using System;
using System.Collections.Generic;

namespace RESCO_RRPAYROLL.Models;

public partial class Nomina
{
    public int Id { get; set; }

    public int IdTipoNomina { get; set; }

    public int? IdEstado { get; set; }

    public int? IdProyecto { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string CreadoPor { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? ModificadoPor { get; set; }

    public virtual Estado? IdEstadoNavigation { get; set; }

    public virtual Proyecto? IdProyectoNavigation { get; set; }

    public virtual TipoNomina IdTipoNominaNavigation { get; set; } = null!;

    public virtual ICollection<NominaDetalle> NominaDetalles { get; set; } = new List<NominaDetalle>();
}
