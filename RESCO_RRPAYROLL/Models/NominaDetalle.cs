using System;
using System.Collections.Generic;

namespace RESCO_RRPAYROLL.Models;

public partial class NominaDetalle
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public decimal SalarioBruto { get; set; }

    public decimal Afp { get; set; }

    public decimal Infotep { get; set; }

    public decimal Isr { get; set; }

    public decimal Sfs { get; set; }

    public decimal SalarioNeto { get; set; }

    public int IdNomina { get; set; }

    public int IdEmpleado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? CreadoPor { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? ModificadoPor { get; set; }

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    public virtual Nomina IdNominaNavigation { get; set; } = null!;

    public virtual ICollection<NominaDeduccione> NominaDeducciones { get; set; } = new List<NominaDeduccione>();

    public virtual ICollection<NominaPercepcione> NominaPercepciones { get; set; } = new List<NominaPercepcione>();

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
