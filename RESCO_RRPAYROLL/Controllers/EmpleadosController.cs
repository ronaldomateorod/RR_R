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

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> VerifyDocumento(string documento)
        {
            var empleado = await _context.Empleados.FirstOrDefaultAsync(e => e.Documento == documento);
            return Json(empleado == null);
        }

        // GET: Empleados
        public async Task<IActionResult> Index()
        {
            var rrpayrollDbContext = _context.Empleados.Include(e => e.IdBancoNavigation).Include(e => e.IdEstadoNavigation).Include(e => e.IdNacionalidadNavigation).Include(e => e.IdProvinciaNavigation).Include(e => e.IdTipoCuentaNavigation);
            return View(await rrpayrollDbContext.ToListAsync());
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
            if (empleado != null)
            {

                string nSexo = empleado.Sexo.ToString();
                string mSexo;

                if (nSexo == "M")
                {
                    mSexo = "Masculino";
                    ViewBag.Sexo = mSexo;
                }
                else
                {
                    mSexo = "Femenino";
                    ViewBag.Sexo = mSexo;
                }
            }

            else
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            ViewData["IdBanco"] = new SelectList(_context.Bancos, "Id", "Nombre");
            ViewData["IdEstado"] = new SelectList(_context.Estados, "Id", "Nombre");
            ViewData["IdNacionalidad"] = new SelectList(_context.Nacionalidades, "Id", "Nombre");
            ViewData["IdProvincia"] = new SelectList(_context.Provincias, "Id", "Nombre");
            ViewData["IdTipoCuenta"] = new SelectList(_context.TipoCuentas, "Id", "Nombre");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Documento,Nombres,Apellidos,FechaNacimiento,Sexo,Direccion,Telefono,Email,IdNacionalidad,IdProvincia,CuentaBancaria,IdTipoCuenta,IdBanco,IdEstado,Contratado,FechaContratacion,FechaLiquidacion,FechaCreacion,CreadoPor,FechaModificacion,ModificadoPor")] Empleado empleado)
        {

            var fechaNacimientoDate = empleado.FechaNacimiento.Date;

            // Asignar fecha convertida
            empleado.FechaNacimiento = fechaNacimientoDate;

            if (empleado.Sexo == "Masculino")
            {
                empleado.Sexo = "M";
            }
            else if (empleado.Sexo == "Femenino")
            {
                empleado.Sexo = "F";
            }


            if (ModelState.IsValid)
            {

                empleado.FechaCreacion = DateTime.Now;
                empleado.FechaContratacion = DateTime.Now;

                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                // Imprimir o revisar errores
                var errores = ModelState.Values.SelectMany(x => x.Errors);

                // Opcional:
                foreach (var error in errores)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            ViewData["IdBanco"] = new SelectList(_context.Bancos, "Id", "Nombre", empleado.IdBanco);
            ViewData["IdEstado"] = new SelectList(_context.Estados, "Id", "Nombre", empleado.IdEstado);
            ViewData["IdNacionalidad"] = new SelectList(_context.Nacionalidades, "Id", "Nombre", empleado.IdNacionalidad);
            ViewData["IdProvincia"] = new SelectList(_context.Provincias, "Id", "Nombre", empleado.IdProvincia);
            ViewData["IdTipoCuenta"] = new SelectList(_context.TipoCuentas, "Id", "Nombre", empleado.IdTipoCuenta);
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
            ViewData["IdBanco"] = new SelectList(_context.Bancos, "Id", "Nombre", empleado.IdBanco);
            ViewData["IdEstado"] = new SelectList(_context.Estados, "Id", "Nombre", empleado.IdEstado);
            ViewData["IdNacionalidad"] = new SelectList(_context.Nacionalidades, "Id", "Nombre", empleado.IdNacionalidad);
            ViewData["IdProvincia"] = new SelectList(_context.Provincias, "Id", "Nombre", empleado.IdProvincia);
            ViewData["IdTipoCuenta"] = new SelectList(_context.TipoCuentas, "Id", "Nombre", empleado.IdTipoCuenta);
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
                    empleado.FechaModificacion = DateTime.Now;
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
            ViewData["IdBanco"] = new SelectList(_context.Bancos, "Id", "Nombre", empleado.IdBanco);
            ViewData["IdEstado"] = new SelectList(_context.Estados, "Id", "Nombre", empleado.IdEstado);
            ViewData["IdNacionalidad"] = new SelectList(_context.Nacionalidades, "Id", "Nombre", empleado.IdNacionalidad);
            ViewData["IdProvincia"] = new SelectList(_context.Provincias, "Id", "Nombre", empleado.IdProvincia);
            ViewData["IdTipoCuenta"] = new SelectList(_context.TipoCuentas, "Id", "Nombre", empleado.IdTipoCuenta);
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
                return Problem("Entity set 'RrpayrollDbContext.Empleados'  is null.");
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
