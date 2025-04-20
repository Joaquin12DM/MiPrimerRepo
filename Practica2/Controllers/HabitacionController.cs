using DomainLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityLayer;

namespace Practica2.Controllers
{
    public class HabitacionController : Controller
    {

        private readonly ReservaService reservaService;

        public HabitacionController(ReservaService reservaService)
        {
           this.reservaService = reservaService;
        }

        private void CargarLista()
        {
            ViewBag.habitacion = reservaService.ListaHabitaciones();


            ViewBag.cliente = reservaService.ListaClientes();

            ViewBag.estado = reservaService.ListaReserva();
        }

        public IActionResult Index()
        {
            var list = reservaService.getAll();

            return View(list);
            
        }
        [HttpPost]
        public IActionResult Buscar(string Nombre)
        {
            if (Nombre == null)
            {
                var reservas = reservaService.getAll();
                return View("Index", reservas);

            }
            var reserva = reservaService.ObtenerReservaPorCliente(Nombre);
            return View("Index", reserva);

        }


        public IActionResult Create()
        {
            CargarLista();
            return View();
        }

        [HttpPost]
        public IActionResult Create(TbReserva reserva)
        {
            if(ModelState.IsValid)
            {
                reservaService.create(reserva);
                return RedirectToAction("Index");

            }
            CargarLista();
            return View(reserva);
        }

        public IActionResult Edit(int id)
        {
            CargarLista();
            var reserva = reservaService.findId(id);
            return View(reserva);
        }

        [HttpPost]
        public IActionResult Edit(TbReserva t)
        {
            if(ModelState.IsValid)
            {
                reservaService.update(t);
                return RedirectToAction(nameof(Index));
            }
            CargarLista();
            return View(t);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
           
            reservaService.delete(id); 
            return RedirectToAction("Index");
        }


    }
}
