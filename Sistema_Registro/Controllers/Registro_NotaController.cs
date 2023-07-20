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
    public class Registro_NotaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Registro_NotaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Registro_Nota
        public async Task<IActionResult> Index()
        {
              return _context.Registro_Notas != null ? 
                          View(await _context.Registro_Notas.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Registro_Notas'  is null.");
        }

        // GET: Registro_Nota/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Registro_Notas == null)
            {
                return NotFound();
            }

            var registro_Nota = await _context.Registro_Notas
                .FirstOrDefaultAsync(m => m.ID == id);
            if (registro_Nota == null)
            {
                return NotFound();
            }

            return View(registro_Nota);
        }

        // GET: Registro_Nota/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Registro_Nota/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Estudiante_ID,Asignatura_ID,Nota1,Nota2,NotaFinal,Aprobada")] Registro_Nota registro_Nota)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registro_Nota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registro_Nota);
        }

        // GET: Registro_Nota/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Registro_Notas == null)
            {
                return NotFound();
            }

            var registro_Nota = await _context.Registro_Notas.FindAsync(id);
            if (registro_Nota == null)
            {
                return NotFound();
            }
            return View(registro_Nota);
        }

        // POST: Registro_Nota/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Estudiante_ID,Asignatura_ID,Nota1,Nota2,NotaFinal,Aprobada")] Registro_Nota registro_Nota)
        {
            if (id != registro_Nota.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registro_Nota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Registro_NotaExists(registro_Nota.ID))
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
            return View(registro_Nota);
        }

        // GET: Registro_Nota/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Registro_Notas == null)
            {
                return NotFound();
            }

            var registro_Nota = await _context.Registro_Notas
                .FirstOrDefaultAsync(m => m.ID == id);
            if (registro_Nota == null)
            {
                return NotFound();
            }

            return View(registro_Nota);
        }

        // POST: Registro_Nota/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Registro_Notas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Registro_Notas'  is null.");
            }
            var registro_Nota = await _context.Registro_Notas.FindAsync(id);
            if (registro_Nota != null)
            {
                _context.Registro_Notas.Remove(registro_Nota);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Registro_NotaExists(int id)
        {
          return (_context.Registro_Notas?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
