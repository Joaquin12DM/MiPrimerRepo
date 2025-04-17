using System;
using System.Collections.Generic;

namespace Practica2.Models;

public partial class TbCliente
{
    public int IdCliente { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string TipoDocumento { get; set; } = null!;

    public string NroDocumento { get; set; } = null!;

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? Nacionalidad { get; set; }

    public string? Direccion { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<TbReserva> TbReservas { get; set; } = new List<TbReserva>();
}
