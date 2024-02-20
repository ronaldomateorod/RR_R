using System;
using System.Collections.Generic;

namespace RESCO_RRPAYROLL.Models;

public partial class NominaDeduccione
{
    public int Id { get; set; }

    public int IdNominaDetalle { get; set; }

    public int IdDeducciones { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? CreadoPor { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? ModificadoPor { get; set; }

    public virtual Deduccione IdDeduccionesNavigation { get; set; } = null!;

    public virtual NominaDetalle IdNominaDetalleNavigation { get; set; } = null!;
}
