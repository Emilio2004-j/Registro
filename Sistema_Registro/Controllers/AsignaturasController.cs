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
    public class AsignaturasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AsignaturasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Asignaturas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Asignaturas.Include(a => a.Aula).Include(a => a.Maestro);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Asignaturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Asignaturas == null)
            {
                return NotFound();
            }

            var asignatura = await _context.Asignaturas
                .Include(a => a.Aula)
                .Include(a => a.Maestro)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (asignatura == null)
            {
                return NotFound();
            }

            return View(asignatura);
        }

        // GET: Asignaturas/Create
        public IActionResult Create()
        {
            ViewData["AulaID"] = new SelectList(_context.Aulas, "ID", "ID");
            ViewData["MaestroID"] = new SelectList(_context.Maestros, "ID", "ID");
            return View();
        }

        // POST: Asignaturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,HoraInicio,HoraFinal,MaestroID,AulaID")] Asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignatura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AulaID"] = new SelectList(_context.Aulas, "ID", "ID", asignatura.AulaID);
            ViewData["MaestroID"] = new SelectList(_context.Maestros, "ID", "ID", asignatura.MaestroID);
            return View(asignatura);
        }

        // GET: Asignaturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Asignaturas == null)
            {
                return NotFound();
            }

            var asignatura = await _context.Asignaturas.FindAsync(id);
            if (asignatura == null)
            {
                return NotFound();
            }
            ViewData["AulaID"] = new SelectList(_context.Aulas, "ID", "ID", asignatura.AulaID);
            ViewData["MaestroID"] = new SelectList(_context.Maestros, "ID", "ID", asignatura.MaestroID);
            return View(asignatura);
        }

        // POST: Asignaturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,HoraInicio,HoraFinal,MaestroID,AulaID")] Asignatura asignatura)
        {
            if (id != asignatura.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignatura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignaturaExists(asignatura.ID))
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
            ViewData["AulaID"] = new SelectList(_context.Aulas, "ID", "ID", asignatura.AulaID);
            ViewData["MaestroID"] = new SelectList(_context.Maestros, "ID", "ID", asignatura.MaestroID);
            return View(asignatura);
        }

        // GET: Asignaturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Asignaturas == null)
            {
                return NotFound();
            }

            var asignatura = await _context.Asignaturas
                .Include(a => a.Aula)
                .Include(a => a.Maestro)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (asignatura == null)
            {
                return NotFound();
            }

            return View(asignatura);
        }

        // POST: Asignaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Asignaturas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Asignaturas'  is null.");
            }
            var asignatura = await _context.Asignaturas.FindAsync(id);
            if (asignatura != null)
            {
                _context.Asignaturas.Remove(asignatura);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignaturaExists(int id)
        {
          return (_context.Asignaturas?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
