using DataLayer;
using EntityLayer;

namespace DomainLayer
{
    public class ReservaService
    {

        private readonly ReservaRepository reservaRepository;

        public ReservaService(ReservaRepository repository)
        {
            this.reservaRepository = repository; 
        }

        public void create(TbReserva reserva)
        {
            reservaRepository.create(reserva);
        }

        public void update(TbReserva reserva)
        {
            reservaRepository.update(reserva);
        }

        public void delete(int id)
        {
            reservaRepository.delete(id);
        }

        public List<TbReserva> getAll()
        {
            return reservaRepository.GetAll();
        }

        public TbReserva findId(int id)
        {
            return reservaRepository.findId(id);
        }

        public IEnumerable<dynamic> ListaHabitaciones()
        {
            return reservaRepository.ListaHabitaciones();
        }
        public IEnumerable<dynamic> ListaClientes()
        {
            return reservaRepository.ListaClientes();
        }
        public IEnumerable<dynamic> ListaReserva()
        {
            return reservaRepository.ListaReserva();
        }

    }
}
