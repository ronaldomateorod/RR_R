using System;
using System.Collections.Generic;

namespace RESCO_RRPAYROLL.Models;

public partial class TipoNomina
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string CreadoPor { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? ModificadoPor { get; set; }

    public virtual ICollection<Nomina> Nominas { get; set; } = new List<Nomina>();
}
