using System;
using System.Collections.Generic;

namespace Practica2.Models;

public partial class TbHotele
{
    public int IdHotel { get; set; }

    public string NombreHotel { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public string Pais { get; set; } = null!;

    public string Categoria { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? SitioWeb { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<TbHabitacione> TbHabitaciones { get; set; } = new List<TbHabitacione>();
}
