using System;
using System.Collections.Generic;

namespace EntityLayer;

public partial class TbServicio
{
    public int IdServicio { get; set; }

    public string NombreServicio { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public virtual ICollection<TbReservasServicio> TbReservasServicios { get; set; } = new List<TbReservasServicio>();
}
