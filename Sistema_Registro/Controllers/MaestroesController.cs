using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sistema_Registro.Data;
using Sistema_Registro.Models;

namespace Sistema_Registro.Controllers
{
    public class MaestroesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MaestroesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Maestroes
        public async Task<IActionResult> Index()
        {
              return _context.Maestros != null ? 
                          View(await _context.Maestros.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Maestros'  is null.");
        }

        // GET: Maestroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Maestros == null)
            {
                return NotFound();
            }

            var maestro = await _context.Maestros
                .FirstOrDefaultAsync(m => m.ID == id);
            if (maestro == null)
            {
                return NotFound();
            }

            return View(maestro);
        }

        // GET: Maestroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Maestroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,Correo,Edad")] Maestro maestro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maestro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(maestro);
        }

        // GET: Maestroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Maestros == null)
            {
                return NotFound();
            }

            var maestro = await _context.Maestros.FindAsync(id);
            if (maestro == null)
            {
                return NotFound();
            }
            return View(maestro);
        }

        // POST: Maestroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,Correo,Edad")] Maestro maestro)
        {
            if (id != maestro.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maestro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaestroExists(maestro.ID))
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
            return View(maestro);
        }

        // GET: Maestroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Maestros == null)
            {
                return NotFound();
            }

            var maestro = await _context.Maestros
                .FirstOrDefaultAsync(m => m.ID == id);
            if (maestro == null)
            {
                return NotFound();
            }

            return View(maestro);
        }

        // POST: Maestroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Maestros == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Maestros'  is null.");
            }
            var maestro = await _context.Maestros.FindAsync(id);
            if (maestro != null)
            {
                _context.Maestros.Remove(maestro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaestroExists(int id)
        {
          return (_context.Maestros?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
