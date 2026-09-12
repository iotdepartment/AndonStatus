using AndonStatus.Data;
using AndonStatus.Models;
using AndonStatus.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AndonStatus.Controllers
{
    public class AndonController : Controller
    {
        private readonly AndonDbContext _context;

        public AndonController(AndonDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _context.AndonRegistros
                .Include(x => x.Estado)
                .Where(x => x.AndonId == 1)
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CambiarEstado()
        {
            var ultimoRegistro = await _context.AndonRegistros
                .Where(x => x.AndonId == 1)
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();

            if (ultimoRegistro == null)
                return NotFound();

            int nuevoEstado = ultimoRegistro.EstadoId switch
            {
                1 => 3,
                3 => 1,
                _ => 1
            };

            var nuevoRegistro = new AndonRegistro
            {
                AndonId = 1,
                EstadoId = nuevoEstado,
                FechaHora = DateTime.Now
            };

            _context.AndonRegistros.Add(nuevoRegistro);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}