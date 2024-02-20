using System;
using System.Collections.Generic;

namespace RESCO_RRPAYROLL.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Rnc { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int IdEstado { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string CreadoPor { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? ModificadoPor { get; set; }

    public virtual Estado IdEstadoNavigation { get; set; } = null!;
}
