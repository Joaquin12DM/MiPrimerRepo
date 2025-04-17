using System;
using System.Collections.Generic;

namespace EntityLayer;

public partial class TbPago
{
    public int IdPago { get; set; }

    public int IdReserva { get; set; }

    public decimal Monto { get; set; }

    public DateTime FechaPago { get; set; }

    public string MetodoPago { get; set; } = null!;

    public string? NroTransaccion { get; set; }

    public string? Estado { get; set; }

    public virtual TbReserva IdReservaNavigation { get; set; } = null!;
}
