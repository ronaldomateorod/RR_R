using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESCO_RRPAYROLL.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RESCO_RRPAYROLL.Models;

public partial class Empleado
{
    [Key]
    public int Id { get; set; }

    //[Unique(typeof(RrpayrollDbContext), nameof(Documento), ErrorMessage = "El documento ya está en uso.")]
    [Remote(action: "VerifyDocumento", controller: "Empleados", ErrorMessage = "El documento ya está en uso.")]
    [Required]
    [DisplayName("Cedula/Pasaporte")]
    public string Documento { get; set; } = null!;

    [Required]
    public string Nombres { get; set; } = null!;

    [Required]
    public string Apellidos { get; set; } = null!;

    [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
    [DataType(DataType.Date)]
    [MinEdad(18, ErrorMessage = "Debes ser mayor de 18 años")]
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    [DisplayName("Fecha de nacimiento")]
    public DateTime FechaNacimiento { get; set; }

    [Required]
    public string Sexo { get; set; } = null!;

    [Required]
    public string Direccion { get; set; } = null!;

    [Required]
    public string Telefono { get; set; } = null!;

    [Required]
    public string Email { get; set; } = null!;

    [DisplayName("Nacionalidad")]
    public int? IdNacionalidad { get; set; }

    [DisplayName("Provincia")]
    public int? IdProvincia { get; set; }

    [DisplayName("Numero de cuenta")]
    public string? CuentaBancaria { get; set; }

    [DisplayName("Tipo de cuenta")]
    public int? IdTipoCuenta { get; set; }

    [DisplayName("Banco")]
    public int? IdBanco { get; set; }

    [DisplayName("Estado")]
    public int? IdEstado { get; set; }

    public bool? Contratado { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    [DisplayName("Fecha de contratacion")]
    public DateTime? FechaContratacion { get; set; }

    public DateTime? FechaLiquidacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? CreadoPor { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? ModificadoPor { get; set; }

    public virtual ICollection<EmpleadoProyecto> EmpleadoProyectos { get; set; } = new List<EmpleadoProyecto>();

    [DisplayName("Banco")]
    public virtual Banco? IdBancoNavigation { get; set; }

    [DisplayName("Estado")]
    public virtual Estado? IdEstadoNavigation { get; set; }

    [DisplayName("Nacionalidad")]
    public virtual Nacionalidade? IdNacionalidadNavigation { get; set; }

    [DisplayName("Provincia")]
    public virtual Provincia? IdProvinciaNavigation { get; set; }

    [DisplayName("Tipo de cuenta")]
    public virtual TipoCuenta? IdTipoCuentaNavigation { get; set; }

    public virtual ICollection<Licencia> Licencia { get; set; } = new List<Licencia>();

    public virtual ICollection<NominaDetalle> NominaDetalles { get; set; } = new List<NominaDetalle>();

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
