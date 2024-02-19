using System;
using System.Collections.Generic;

namespace RESCO_RRPAYROLL.Models;

public partial class RolUsuario
{
    public int Id { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdRol { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? ModificadoPor { get; set; }

    public virtual Role? IdRolNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
