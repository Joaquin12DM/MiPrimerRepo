using System;
using System.Collections.Generic;

namespace Practica2.Models;

public partial class TbReservasServicio
{
    public int IdReservaServicio { get; set; }

    public int IdReserva { get; set; }

    public int IdServicio { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal Subtotal { get; set; }

    public virtual TbReserva IdReservaNavigation { get; set; } = null!;

    public virtual TbServicio IdServicioNavigation { get; set; } = null!;
}
