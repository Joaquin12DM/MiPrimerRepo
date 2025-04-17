using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica2.Models;

namespace Practica2.Controllers
{
    public class HabitacionController : Controller
    {

        private readonly HotelDbexamenContext _context;

        public HabitacionController(HotelDbexamenContext context)
        {
            _context = context;
        }

        private void CargarLista()
        {
            ViewBag.habitacion = _context.TbHabitaciones.Select(a => 
            new { a.IdHabitacion, a.NroHabitacion }).ToList();


            ViewBag.cliente = _context.TbClientes.Select(c =>
            new { c.IdCliente, c.Nombres, c.Apellidos }).ToList();

            ViewBag.estado = _context.TbReservas.Select(e => e.Estado)
                .Distinct()
                .ToList();
        }

        public IActionResult Index()
        {
            var reserva = _context.TbReservas
                .Include(c => c.IdClienteNavigation)
                .Include(a => a.IdHabitacionNavigation!.IdTipoNavigation)
                .ToList();
            return View(reserva);
            
        }

        public IActionResult Create()
        {
            CargarLista();
            return View(new TbReserva());
        }

        [HttpPost]
        public IActionResult Create(TbReserva t)
        {
            if(ModelState.IsValid)
            {
                _context.TbReservas.Add(t);      
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            CargarLista();
            return View(t);
        }

        public IActionResult Edit(int id)
        {
            CargarLista();
            var reserva = _context.TbReservas.Find(id);
            return View(reserva);
        }

        [HttpPost]
        public IActionResult Edit(TbReserva t)
        {
            if(ModelState.IsValid)
            {
                _context.TbReservas.Update(t);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            CargarLista();
            return View(t);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var r = _context.TbReservas.Find(id);
            if (r == null)
            {
                return NotFound(); 
            }
            _context.TbReservas.Remove(r);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
