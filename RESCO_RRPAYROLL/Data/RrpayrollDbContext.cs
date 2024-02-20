using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RESCO_RRPAYROLL.Models;

namespace RESCO_RRPAYROLL.Data;

public partial class RrpayrollDbContext : DbContext
{
    public RrpayrollDbContext()
    {
    }

    public RrpayrollDbContext(DbContextOptions<RrpayrollDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actividade> Actividades { get; set; }

    public virtual DbSet<ActividadesAsignada> ActividadesAsignadas { get; set; }

    public virtual DbSet<Asistencia> Asistencias { get; set; }

    public virtual DbSet<Banco> Bancos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Deduccione> Deducciones { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<EmpleadoProyecto> EmpleadoProyectos { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Hora> Horas { get; set; }

    public virtual DbSet<Licencia> Licencias { get; set; }

    public virtual DbSet<Nacionalidade> Nacionalidades { get; set; }

    public virtual DbSet<Nomina> Nominas { get; set; }

    public virtual DbSet<NominaDeduccione> NominaDeducciones { get; set; }

    public virtual DbSet<NominaDetalle> NominaDetalles { get; set; }

    public virtual DbSet<NominaPercepcione> NominaPercepciones { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Percepcione> Percepciones { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Provincia> Provincias { get; set; }

    public virtual DbSet<Proyecto> Proyectos { get; set; }

    public virtual DbSet<Puesto> Puestos { get; set; }

    public virtual DbSet<RolUsuario> RolUsuarios { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<TipoCuenta> TipoCuentas { get; set; }

    public virtual DbSet<TipoNomina> TipoNominas { get; set; }

    public virtual DbSet<TipoPago> TipoPagos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=RRPAYROLL_DB;Trusted_connection=True;MultipleActiveResultSets=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actividade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Activida__3214EC07876B45F0");

            entity.Property(e => e.CreadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Titulo)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdProyectoNavigation).WithMany(p => p.Actividades)
                .HasForeignKey(d => d.IdProyecto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Actividad__IdPro__6EF57B66");
        });

        modelBuilder.Entity<ActividadesAsignada>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Activida__3214EC0736C19EBE");

            entity.Property(e => e.CreadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdActividadNavigation).WithMany(p => p.ActividadesAsignada)
                .HasForeignKey(d => d.IdActividad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Actividad__IdAct__71D1E811");

            entity.HasOne(d => d.IdEmpleadoProyectoNavigation).WithMany(p => p.ActividadesAsignada)
                .HasForeignKey(d => d.IdEmpleadoProyecto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Actividad__IdEmp__72C60C4A");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.ActividadesAsignada)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Actividad__IdEst__73BA3083");
        });

        modelBuilder.Entity<Asistencia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Asistenc__3214EC07F8EEE7E3");

            entity.Property(e => e.CreadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEmpleadoProyectoNavigation).WithMany(p => p.Asistencia)
                .HasForeignKey(d => d.IdEmpleadoProyecto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Asistenci__IdEmp__66603565");
        });

        modelBuilder.Entity<Banco>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bancos__3214EC070D747A03");

            entity.Property(e => e.CreadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clientes__3214EC077E86F771");

            entity.Property(e => e.CreadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Rnc)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("RNC");
            entity.Property(e => e.Telefono)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Clientes__IdEsta__4E88ABD4");
        });

        modelBuilder.Entity<Deduccione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Deduccio__3214EC078BE63203");

            entity.Property(e => e.CreadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Empleado__3214EC0753FFB572");

            entity.HasIndex(e => e.Documento, "UQ__Empleado__AF73706DD398E309").IsUnique();

            entity.Property(e => e.Apellidos)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CreadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CuentaBancaria)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Documento)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Telefono)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdBancoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdBanco)
                .HasConstraintName("FK__Empleados__IdBan__4AB81AF0");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Empleados__IdEst__4BAC3F29");

            entity.HasOne(d => d.IdNacionalidadNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdNacionalidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Empleados__IdNac__47DBAE45");

            entity.HasOne(d => d.IdProvinciaNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdProvincia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Empleados__IdPro__48CFD27E");

            entity.HasOne(d => d.IdTipoCuentaNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdTipoCuenta)
                .HasConstraintName("FK__Empleados__IdTip__49C3F6B7");
        });

        modelBuilder.Entity<EmpleadoProyecto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Empleado__3214EC077E5CEBDD");

            entity.Property(e => e.CreadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.EmpleadoProyectos)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmpleadoP__IdEmp__6383C8BA");

            entity.HasOne(d => d.IdProyectoNavigation).WithMany(p => p.EmpleadoProyectos)
                .HasForeignKey(d => d.IdProyecto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmpleadoP__IdPro__628FA481");

            entity.HasOne(d => d.IdPuestoNavigation).WithMany(p => p.EmpleadoProyectos)
                .HasForeignKey(d => d.IdPuesto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmpleadoP__IdPue__619B8048");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Estados__3214EC070B214941");

            entity.Property(e => e.CreadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Hora>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Horas__3214EC07028AC8D4");

            entity.Property(e => e.CreadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAsistenciaNavigation).WithMany(p => p.Horas)
                .HasForeignKey(d => d.IdAsistencia)
                .HasConstraintName("FK__Horas__IdAsisten__693CA210");
        });

        modelBuilder.Entity<Licencia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Licencia__3214EC07F7792DD9");

            entity.Property(e => e.CreadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Motivo)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Licencia)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Licencias__IdEmp__5BE2A6F2");
        });

        modelBuilder.Entity<Nacionalidade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Nacional__3214EC0776B3EFF1");

            entity.Property(e => e.CreadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Nomina>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Nominas__3214EC07C960DCE3");

            entity.Property(e => e.CreadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Nominas)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK__Nominas__IdEstad__797309D9");

            entity.HasOne(d => d.IdProyectoNavigation).WithMany(p => p.Nominas)
                .HasForeignKey(d => d.IdProyecto)
                .HasConstraintName("FK__Nominas__IdProye__7A672E12");

            entity.HasOne(d => d.IdTipoNominaNavigation).WithMany(p => p.Nominas)
                .HasForeignKey(d => d.IdTipoNomina)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Nominas__IdTipoN__787EE5A0");
        });

        modelBuilder.Entity<NominaDeduccione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Nomina_D__3214EC07F7CD67D2");

            entity.ToTable("Nomina_Deducciones");

            entity.Property(e => e.CreadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdDeduccionesNavigation).WithMany(p => p.NominaDeducciones)
                .HasForeignKey(d => d.IdDeducciones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Nomina_De__IdDed__05D8E0BE");

            entity.HasOne(d => d.IdNominaDetalleNavigation).WithMany(p => p.NominaDeducciones)
                .HasForeignKey(d => d.IdNominaDetalle)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Nomina_De__IdNom__04E4BC85");
        });

        modelBuilder.Entity<NominaDetalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NominaDe__3214EC072CC3E24E");

            entity.ToTable("NominaDetalle");

            entity.Property(e => e.Afp)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("AFP");
            entity.Property(e => e.CreadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Infotep)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("INFOTEP");
            entity.Property(e => e.Isr)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ISR");
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.SalarioBruto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SalarioNeto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Sfs)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SFS");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.NominaDetalles)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NominaDet__IdEmp__7E37BEF6");

            entity.HasOne(d => d.IdNominaNavigation).WithMany(p => p.NominaDetalles)
                .HasForeignKey(d => d.IdNomina)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NominaDet__IdNom__7D439ABD");
        });

        modelBuilder.Entity<NominaPercepcione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Nomina_P__3214EC072292A483");

            entity.ToTable("Nomina_Percepciones");

            entity.Property(e => e.CreadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdNominaDetalleNavigation).WithMany(p => p.NominaPercepciones)
                .HasForeignKey(d => d.IdNominaDetalle)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Nomina_Pe__IdNom__01142BA1");

            entity.HasOne(d => d.IdPercepcionesNavigation).WithMany(p => p.NominaPercepciones)
                .HasForeignKey(d => d.IdPercepciones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Nomina_Pe__IdPer__02084FDA");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pagos__3214EC07FF2A807B");

            entity.Property(e => e.Comision).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CreadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("FK__Pagos__IdEmplead__0A9D95DB");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK__Pagos__IdEstado__0C85DE4D");

            entity.HasOne(d => d.IdNominaDetalleNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdNominaDetalle)
                .HasConstraintName("FK__Pagos__IdNominaD__0B91BA14");
        });

        modelBuilder.Entity<Percepcione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Percepci__3214EC07E1207101");

            entity.Property(e => e.CreadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Permisos__3214EC07EF167763");

            entity.Property(e => e.CreadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FechaMcreacion).HasColumnName("FechaMCreacion");
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Motivo)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAsistenciaNavigation).WithMany(p => p.Permisos)
                .HasForeignKey(d => d.IdAsistencia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Permisos__IdAsis__6C190EBB");
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Provinci__3214EC078595B61E");

            entity.Property(e => e.CreadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proyecto__3214EC0772805985");

            entity.Property(e => e.Cliente)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CreadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Locacion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proyectos__IdEst__5EBF139D");
        });

        modelBuilder.Entity<Puesto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Puestos__3214EC073CA7DFE3");

            entity.Property(e => e.CreadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RolUsuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RolUsuar__3214EC07D52DA41B");

            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.RolUsuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__RolUsuari__IdRol__59063A47");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.RolUsuarios)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__RolUsuari__IdUsu__5812160E");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC075CE332EC");

            entity.Property(e => e.CreadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoCuenta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoCuen__3214EC070AABBFFC");

            entity.Property(e => e.CreadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoNomina>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoNomi__3214EC073BA352FF");

            entity.ToTable("TipoNomina");

            entity.Property(e => e.CreadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoPago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoPago__3214EC079625CFCA");

            entity.ToTable("TipoPago");

            entity.Property(e => e.CreadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC076E301700");

            entity.HasIndex(e => e.Nombre, "UQ__Usuarios__75E3EFCFA9105AEF").IsUnique();

            entity.Property(e => e.Contrasena)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ContrasenaAnterior)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CreadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("FK__Usuarios__IdEmpl__5441852A");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuarios__IdEsta__5535A963");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
