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
    public class TipoCuentasController : Controller
    {
        private readonly RrpayrollDbContext _context;

        public TipoCuentasController(RrpayrollDbContext context)
        {
            _context = context;
        }

        // GET: TipoCuentas
        public async Task<IActionResult> Index()
        {
              return _context.TipoCuentas != null ? 
                          View(await _context.TipoCuentas.ToListAsync()) :
                          Problem("Entity set 'RrpayrollDbContext.TipoCuentas'  is null.");
        }

        // GET: TipoCuentas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoCuentas == null)
            {
                return NotFound();
            }

            var tipoCuenta = await _context.TipoCuentas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoCuenta == null)
            {
                return NotFound();
            }

            return View(tipoCuenta);
        }

        // GET: TipoCuentas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoCuentas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,FechaCreacion,CreadoPor,FechaModificacion,ModificadoPor")] TipoCuenta tipoCuenta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoCuenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoCuenta);
        }

        // GET: TipoCuentas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoCuentas == null)
            {
                return NotFound();
            }

            var tipoCuenta = await _context.TipoCuentas.FindAsync(id);
            if (tipoCuenta == null)
            {
                return NotFound();
            }
            return View(tipoCuenta);
        }

        // POST: TipoCuentas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,FechaCreacion,CreadoPor,FechaModificacion,ModificadoPor")] TipoCuenta tipoCuenta)
        {
            if (id != tipoCuenta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoCuenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoCuentaExists(tipoCuenta.Id))
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
            return View(tipoCuenta);
        }

        // GET: TipoCuentas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoCuentas == null)
            {
                return NotFound();
            }

            var tipoCuenta = await _context.TipoCuentas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoCuenta == null)
            {
                return NotFound();
            }

            return View(tipoCuenta);
        }

        // POST: TipoCuentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoCuentas == null)
            {
                return Problem("Entity set 'RrpayrollDbContext.TipoCuentas'  is null.");
            }
            var tipoCuenta = await _context.TipoCuentas.FindAsync(id);
            if (tipoCuenta != null)
            {
                _context.TipoCuentas.Remove(tipoCuenta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoCuentaExists(int id)
        {
          return (_context.TipoCuentas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
