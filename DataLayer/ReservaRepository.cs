using Microsoft.EntityFrameworkCore;
using EntityLayer;

namespace DataLayer
{
    public class ReservaRepository
    {

        private readonly HotelDbexamenContext _context;

        public ReservaRepository(HotelDbexamenContext context)
        {
            _context = context;
        }

        public void create(TbReserva reserva)
        {
            _context.Add(reserva);
            _context.SaveChanges();
        }

        public void update(TbReserva reserva)
        {
            _context.Update(reserva);
            _context.SaveChanges();
        }

        public void delete(int id)
        {
            var reserva = findId(id);

            if (reserva != null)
            {
                _context.Remove(reserva);
                _context.SaveChanges();
            }
        }

        public List<TbReserva> GetAll()
        {
            var list = _context.TbReservas
                .Include(c => c.IdClienteNavigation)
                .Include(h => h.IdHabitacionNavigation!.IdTipoNavigation)
                .ToList();
            return list;
        }

        public TbReserva findId(int id)
        {
            return _context.TbReservas.Find(id);
            
        }

        public IEnumerable<HabitacionDTO> ListaHabitaciones()
        {
           return _context.TbHabitaciones.Select(a =>
            new HabitacionDTO{
                IdHabitacion = a.IdHabitacion,
                NroHabitacion = a.NroHabitacion
            }).ToList();
        }

        public IEnumerable<ClienteDTO> ListaClientes()
        {
            return _context.TbClientes.Select(c => new ClienteDTO
            {
                IdCliente = c.IdCliente,
                Nombres = c.Nombres,
                Apellidos = c.Apellidos
            }).ToList();
        }

        public IEnumerable<dynamic> ListaReserva()
        {
            return _context.TbReservas.Select(e => e.Estado)
                .Distinct()
                .ToList();
        }


    }
}
