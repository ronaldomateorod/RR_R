using System;
using System.Collections.Generic;

namespace RESCO_RRPAYROLL.Models;

public partial class Pago
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public decimal Monto { get; set; }

    public decimal Comision { get; set; }

    public int? IdEmpleado { get; set; }

    public int? IdNominaDetalle { get; set; }

    public int? IdEstado { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string CreadoPor { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? ModificadoPor { get; set; }

    public virtual Empleado? IdEmpleadoNavigation { get; set; }

    public virtual Estado? IdEstadoNavigation { get; set; }

    public virtual NominaDetalle? IdNominaDetalleNavigation { get; set; }
}
