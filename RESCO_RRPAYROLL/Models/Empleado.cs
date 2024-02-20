using System;
using System.Collections.Generic;

namespace RESCO_RRPAYROLL.Models;

public partial class Empleado
{
    public int Id { get; set; }

    public string Documento { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public string Sexo { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int IdNacionalidad { get; set; }

    public int IdProvincia { get; set; }

    public string? CuentaBancaria { get; set; }

    public int? IdTipoCuenta { get; set; }

    public int? IdBanco { get; set; }

    public int IdEstado { get; set; }

    public bool? Contratado { get; set; }

    public DateTime? FechaContratacion { get; set; }

    public DateTime? FechaLiquidacion { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string CreadoPor { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? ModificadoPor { get; set; }

    public virtual ICollection<EmpleadoProyecto> EmpleadoProyectos { get; set; } = new List<EmpleadoProyecto>();

    public virtual Banco? IdBancoNavigation { get; set; }

    public virtual Estado IdEstadoNavigation { get; set; } = null!;

    public virtual Nacionalidade IdNacionalidadNavigation { get; set; } = null!;

    public virtual Provincia IdProvinciaNavigation { get; set; } = null!;

    public virtual TipoCuenta? IdTipoCuentaNavigation { get; set; }

    public virtual ICollection<Licencia> Licencia { get; set; } = new List<Licencia>();

    public virtual ICollection<NominaDetalle> NominaDetalles { get; set; } = new List<NominaDetalle>();

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
