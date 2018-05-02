using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServicuerosSA.Data;
using ServicuerosSA.Models;

namespace ServicuerosSA.Controllers
{
    public class ClasificacionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClasificacionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Clasificaciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clasificacion.ToListAsync());
        }

        // GET: Clasificaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasificacion = await _context.Clasificacion
                .SingleOrDefaultAsync(m => m.ClasificacionId == id);
            if (clasificacion == null)
            {
                return NotFound();
            }

            return View(clasificacion);
        }

        // GET: Clasificaciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clasificaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClasificacionId,Selecciones")] Clasificacion clasificacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clasificacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clasificacion);
        }

        // GET: Clasificaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasificacion = await _context.Clasificacion.SingleOrDefaultAsync(m => m.ClasificacionId == id);
            if (clasificacion == null)
            {
                return NotFound();
            }
            return View(clasificacion);
        }

        // POST: Clasificaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClasificacionId,Selecciones")] Clasificacion clasificacion)
        {
            if (id != clasificacion.ClasificacionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clasificacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClasificacionExists(clasificacion.ClasificacionId))
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
            return View(clasificacion);
        }

        // GET: Clasificaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasificacion = await _context.Clasificacion
                .SingleOrDefaultAsync(m => m.ClasificacionId == id);
            if (clasificacion == null)
            {
                return NotFound();
            }

            return View(clasificacion);
        }

        // POST: Clasificaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clasificacion = await _context.Clasificacion.SingleOrDefaultAsync(m => m.ClasificacionId == id);
            _context.Clasificacion.Remove(clasificacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClasificacionExists(int id)
        {
            return _context.Clasificacion.Any(e => e.ClasificacionId == id);
        }
    }
}
