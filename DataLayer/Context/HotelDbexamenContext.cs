using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityLayer;

public partial class HotelDbexamenContext : DbContext
{
    public HotelDbexamenContext()
    {
    }

    public HotelDbexamenContext(DbContextOptions<HotelDbexamenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbCliente> TbClientes { get; set; }

    public virtual DbSet<TbHabitacione> TbHabitaciones { get; set; }

    public virtual DbSet<TbHotele> TbHoteles { get; set; }

    public virtual DbSet<TbPago> TbPagos { get; set; }

    public virtual DbSet<TbReserva> TbReservas { get; set; }

    public virtual DbSet<TbReservasServicio> TbReservasServicios { get; set; }

    public virtual DbSet<TbServicio> TbServicios { get; set; }

    public virtual DbSet<TbTipoHabitacione> TbTipoHabitaciones { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbCliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__tb_clien__677F38F54AD139A4");

            entity.ToTable("tb_clientes");

            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Nacionalidad)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nacionalidad");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.NroDocumento)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nro_documento");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo_documento");
        });

        modelBuilder.Entity<TbHabitacione>(entity =>
        {
            entity.HasKey(e => e.IdHabitacion).HasName("PK__tb_habit__773F28F38D4C42E4");

            entity.ToTable("tb_habitaciones");

            entity.Property(e => e.IdHabitacion).HasColumnName("id_habitacion");
            entity.Property(e => e.Capacidad).HasColumnName("capacidad");
            entity.Property(e => e.Caracteristicas)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("caracteristicas");
            entity.Property(e => e.Disponible).HasColumnName("disponible");
            entity.Property(e => e.IdHotel).HasColumnName("id_hotel");
            entity.Property(e => e.IdTipo).HasColumnName("id_tipo");
            entity.Property(e => e.NroHabitacion)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("nro_habitacion");
            entity.Property(e => e.Piso).HasColumnName("piso");
            entity.Property(e => e.PrecioNoche)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio_noche");

            entity.HasOne(d => d.IdHotelNavigation).WithMany(p => p.TbHabitaciones)
                .HasForeignKey(d => d.IdHotel)
                .HasConstraintName("FK__tb_habita__id_ho__403A8C7D");

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.TbHabitaciones)
                .HasForeignKey(d => d.IdTipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tb_habita__id_ti__412EB0B6");
        });

        modelBuilder.Entity<TbHotele>(entity =>
        {
            entity.HasKey(e => e.IdHotel).HasName("PK__tb_hotel__EAD9D9284DBDA5D9");

            entity.ToTable("tb_hoteles");

            entity.Property(e => e.IdHotel).HasColumnName("id_hotel");
            entity.Property(e => e.Categoria)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("categoria");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ciudad");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.NombreHotel)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_hotel");
            entity.Property(e => e.Pais)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pais");
            entity.Property(e => e.SitioWeb)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("sitio_web");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<TbPago>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PK__tb_pagos__0941B074ACD0B2C7");

            entity.ToTable("tb_pagos");

            entity.Property(e => e.IdPago).HasColumnName("id_pago");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaPago)
                .HasColumnType("datetime")
                .HasColumnName("fecha_pago");
            entity.Property(e => e.IdReserva).HasColumnName("id_reserva");
            entity.Property(e => e.MetodoPago)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("metodo_pago");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("monto");
            entity.Property(e => e.NroTransaccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nro_transaccion");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.TbPagos)
                .HasForeignKey(d => d.IdReserva)
                .HasConstraintName("FK__tb_pagos__id_res__4F7CD00D");
        });

        modelBuilder.Entity<TbReserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("PK__tb_reser__423CBE5D1C54A17C");

            entity.ToTable("tb_reservas");

            entity.Property(e => e.IdReserva).HasColumnName("id_reserva");
            entity.Property(e => e.Comentarios)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("comentarios");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaEntrada)
                .HasColumnType("datetime")
                .HasColumnName("fecha_entrada");
            entity.Property(e => e.FechaReserva)
                .HasColumnType("datetime")
                .HasColumnName("fecha_reserva");
            entity.Property(e => e.FechaSalida)
                .HasColumnType("datetime")
                .HasColumnName("fecha_salida");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdHabitacion).HasColumnName("id_habitacion");
            entity.Property(e => e.NroPersonas).HasColumnName("nro_personas");
            entity.Property(e => e.PrecioTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio_total");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.TbReservas)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tb_reserv__id_cl__46E78A0C");

            entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.TbReservas)
                .HasForeignKey(d => d.IdHabitacion)
                .HasConstraintName("FK__tb_reserv__id_ha__45F365D3");
        });

        modelBuilder.Entity<TbReservasServicio>(entity =>
        {
            entity.HasKey(e => e.IdReservaServicio).HasName("PK__tb_reser__CBCF4E1CF717415D");

            entity.ToTable("tb_reservas_servicios");

            entity.Property(e => e.IdReservaServicio).HasColumnName("id_reserva_servicio");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.IdReserva).HasColumnName("id_reserva");
            entity.Property(e => e.IdServicio).HasColumnName("id_servicio");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio_unitario");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("subtotal");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.TbReservasServicios)
                .HasForeignKey(d => d.IdReserva)
                .HasConstraintName("FK__tb_reserv__id_re__4BAC3F29");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.TbReservasServicios)
                .HasForeignKey(d => d.IdServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tb_reserv__id_se__4CA06362");
        });

        modelBuilder.Entity<TbServicio>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PK__tb_servi__6FD07FDC35F4E149");

            entity.ToTable("tb_servicios");

            entity.Property(e => e.IdServicio).HasColumnName("id_servicio");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.NombreServicio)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_servicio");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
        });

        modelBuilder.Entity<TbTipoHabitacione>(entity =>
        {
            entity.HasKey(e => e.IdTipo).HasName("PK__tb_tipo___CF90108993EADC87");

            entity.ToTable("tb_tipo_habitaciones");

            entity.Property(e => e.IdTipo).HasColumnName("id_tipo");
            entity.Property(e => e.CapacidadMax).HasColumnName("capacidad_max");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.NombreTipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_tipo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
