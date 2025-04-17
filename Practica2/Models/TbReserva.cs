using System;
using System.Collections.Generic;

namespace Practica2.Models;

public partial class TbReserva
{
    public int IdReserva { get; set; }

    public int IdHabitacion { get; set; }

    public int IdCliente { get; set; }

    public DateTime FechaReserva { get; set; } = DateTime.Now;

    public DateTime FechaEntrada { get; set; } = DateTime.Now;

    public DateTime FechaSalida { get; set; } = DateTime.Now;

    public int NroPersonas { get; set; }

    public decimal PrecioTotal { get; set; }

    public string? Estado { get; set; }

    public string? Comentarios { get; set; }

    public virtual TbCliente? IdClienteNavigation { get; set; }

    public virtual TbHabitacione? IdHabitacionNavigation { get; set; }

    public virtual ICollection<TbPago> TbPagos { get; set; } = new List<TbPago>();

    public virtual ICollection<TbReservasServicio> TbReservasServicios { get; set; } = new List<TbReservasServicio>();
}
