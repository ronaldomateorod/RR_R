using System;
using System.Collections.Generic;

namespace RESCO_RRPAYROLL.Models;

public partial class Percepcione
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Monto { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string CreadoPor { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? ModificadoPor { get; set; }

    public bool? Default { get; set; }

    public virtual ICollection<NominaPercepcione> NominaPercepciones { get; set; } = new List<NominaPercepcione>();
}
