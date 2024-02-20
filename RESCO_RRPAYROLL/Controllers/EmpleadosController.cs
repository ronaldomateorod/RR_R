using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RESCO_RRPAYROLL.Data;
using RESCO_RRPAYROLL.Models;

namespace RESCO_RRPAYROLL.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly RrpayrollDbContext _context;

        public EmpleadosController(RrpayrollDbContext context)
        {
            _context = context;
        }

        // GET: Empleados
        public async Task<IActionResult> Index()
        {
            var rRPAYROLL_DBContext = _context.Empleados.Include(e => e.IdBancoNavigation).Include(e => e.IdEstadoNavigation).Include(e => e.IdNacionalidadNavigation).Include(e => e.IdProvinciaNavigation).Include(e => e.IdTipoCuentaNavigation);
            return View(await rRPAYROLL_DBContext.ToListAsync());
        }

        // GET: Empleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.IdBancoNavigation)
                .Include(e => e.IdEstadoNavigation)
                .Include(e => e.IdNacionalidadNavigation)
                .Include(e => e.IdProvinciaNavigation)
                .Include(e => e.IdTipoCuentaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            ViewData["IdBanco"] = new SelectList(_context.Bancos, "Id", "Id");
            ViewData["IdEstado"] = new SelectList(_context.Estados, "Id", "Id");
            ViewData["IdNacionalidad"] = new SelectList(_context.Nacionalidades, "Id", "Id");
            ViewData["IdProvincia"] = new SelectList(_context.Provincias, "Id", "Id");
            ViewData["IdTipoCuenta"] = new SelectList(_context.TipoCuentas, "Id", "Id");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Documento,Nombres,Apellidos,FechaNacimiento,Sexo,Direccion,Telefono,Email,IdNacionalidad,IdProvincia,CuentaBancaria,IdTipoCuenta,IdBanco,IdEstado,Contratado,FechaContratacion,FechaLiquidacion,FechaCreacion,CreadoPor,FechaModificacion,ModificadoPor")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBanco"] = new SelectList(_context.Bancos, "Id", "Id", empleado.IdBanco);
            ViewData["IdEstado"] = new SelectList(_context.Estados, "Id", "Id", empleado.IdEstado);
            ViewData["IdNacionalidad"] = new SelectList(_context.Nacionalidades, "Id", "Id", empleado.IdNacionalidad);
            ViewData["IdProvincia"] = new SelectList(_context.Provincias, "Id", "Id", empleado.IdProvincia);
            ViewData["IdTipoCuenta"] = new SelectList(_context.TipoCuentas, "Id", "Id", empleado.IdTipoCuenta);
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            ViewData["IdBanco"] = new SelectList(_context.Bancos, "Id", "Id", empleado.IdBanco);
            ViewData["IdEstado"] = new SelectList(_context.Estados, "Id", "Id", empleado.IdEstado);
            ViewData["IdNacionalidad"] = new SelectList(_context.Nacionalidades, "Id", "Id", empleado.IdNacionalidad);
            ViewData["IdProvincia"] = new SelectList(_context.Provincias, "Id", "Id", empleado.IdProvincia);
            ViewData["IdTipoCuenta"] = new SelectList(_context.TipoCuentas, "Id", "Id", empleado.IdTipoCuenta);
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Documento,Nombres,Apellidos,FechaNacimiento,Sexo,Direccion,Telefono,Email,IdNacionalidad,IdProvincia,CuentaBancaria,IdTipoCuenta,IdBanco,IdEstado,Contratado,FechaContratacion,FechaLiquidacion,FechaCreacion,CreadoPor,FechaModificacion,ModificadoPor")] Empleado empleado)
        {
            if (id != empleado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBanco"] = new SelectList(_context.Bancos, "Id", "Id", empleado.IdBanco);
            ViewData["IdEstado"] = new SelectList(_context.Estados, "Id", "Id", empleado.IdEstado);
            ViewData["IdNacionalidad"] = new SelectList(_context.Nacionalidades, "Id", "Id", empleado.IdNacionalidad);
            ViewData["IdProvincia"] = new SelectList(_context.Provincias, "Id", "Id", empleado.IdProvincia);
            ViewData["IdTipoCuenta"] = new SelectList(_context.TipoCuentas, "Id", "Id", empleado.IdTipoCuenta);
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.IdBancoNavigation)
                .Include(e => e.IdEstadoNavigation)
                .Include(e => e.IdNacionalidadNavigation)
                .Include(e => e.IdProvinciaNavigation)
                .Include(e => e.IdTipoCuentaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Empleados == null)
            {
                return Problem("Entity set 'RRPAYROLL_DBContext.Empleados'  is null.");
            }
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
          return (_context.Empleados?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
