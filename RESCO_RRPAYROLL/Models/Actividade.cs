using System;
using System.Collections.Generic;

namespace RESCO_RRPAYROLL.Models;

public partial class Actividade
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Monto { get; set; }

    public int IdProyecto { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? CreadoPor { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? ModificadoPor { get; set; }

    public virtual ICollection<ActividadesAsignada> ActividadesAsignada { get; set; } = new List<ActividadesAsignada>();

    public virtual Proyecto IdProyectoNavigation { get; set; } = null!;
}
