using System;
using System.Collections.Generic;

namespace RESCO_RRPAYROLL.Models;

public partial class NominaPercepcione
{
    public int Id { get; set; }

    public int IdNominaDetalle { get; set; }

    public int IdPercepciones { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string CreadoPor { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? ModificadoPor { get; set; }

    public virtual NominaDetalle IdNominaDetalleNavigation { get; set; } = null!;

    public virtual Percepcione IdPercepcionesNavigation { get; set; } = null!;
}
