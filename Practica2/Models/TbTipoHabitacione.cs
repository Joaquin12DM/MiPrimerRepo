using System;
using System.Collections.Generic;

namespace Practica2.Models;

public partial class TbTipoHabitacione
{
    public int IdTipo { get; set; }

    public string NombreTipo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int CapacidadMax { get; set; }

    public virtual ICollection<TbHabitacione> TbHabitaciones { get; set; } = new List<TbHabitacione>();
}
