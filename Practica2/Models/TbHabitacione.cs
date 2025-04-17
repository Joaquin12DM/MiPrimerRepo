using System;
using System.Collections.Generic;

namespace Practica2.Models;

public partial class TbHabitacione
{
    public int IdHabitacion { get; set; }

    public string NroHabitacion { get; set; } = null!;

    public int IdHotel { get; set; }

    public int IdTipo { get; set; }

    public decimal PrecioNoche { get; set; }

    public int Capacidad { get; set; }

    public int Piso { get; set; }

    public bool Disponible { get; set; }

    public string? Caracteristicas { get; set; }

    public virtual TbHotele IdHotelNavigation { get; set; } = null!;

    public virtual TbTipoHabitacione IdTipoNavigation { get; set; } = null!;

    public virtual ICollection<TbReserva> TbReservas { get; set; } = new List<TbReserva>();
}
