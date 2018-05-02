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
    public class BodegasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BodegasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bodegas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Bodega.Include(b => b.TiposBodega);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Bodegas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodega = await _context.Bodega
                .Include(b => b.TiposBodega)
                .SingleOrDefaultAsync(m => m.BodegaId == id);
            if (bodega == null)
            {
                return NotFound();
            }

            return View(bodega);
        }

        // GET: Bodegas/Create
        public IActionResult Create()
        {
            ViewData["TipoBodegaId"] = new SelectList(_context.Set<TipoBodega>(), "TipoBodegaId", "TipoBodegaId");
            return View();
        }

        // POST: Bodegas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BodegaId,NombreBodega,Ubicacion,CantidadAlmacenamiento,NumeroEstantes,TipoBodegaId")] Bodega bodega)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bodega);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoBodegaId"] = new SelectList(_context.Set<TipoBodega>(), "TipoBodegaId", "TipoBodegaId", bodega.TipoBodegaId);
            return View(bodega);
        }

        // GET: Bodegas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodega = await _context.Bodega.SingleOrDefaultAsync(m => m.BodegaId == id);
            if (bodega == null)
            {
                return NotFound();
            }
            ViewData["TipoBodegaId"] = new SelectList(_context.Set<TipoBodega>(), "TipoBodegaId", "TipoBodegaId", bodega.TipoBodegaId);
            return View(bodega);
        }

        // POST: Bodegas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BodegaId,NombreBodega,Ubicacion,CantidadAlmacenamiento,NumeroEstantes,TipoBodegaId")] Bodega bodega)
        {
            if (id != bodega.BodegaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bodega);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BodegaExists(bodega.BodegaId))
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
            ViewData["TipoBodegaId"] = new SelectList(_context.Set<TipoBodega>(), "TipoBodegaId", "TipoBodegaId", bodega.TipoBodegaId);
            return View(bodega);
        }

        // GET: Bodegas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodega = await _context.Bodega
                .Include(b => b.TiposBodega)
                .SingleOrDefaultAsync(m => m.BodegaId == id);
            if (bodega == null)
            {
                return NotFound();
            }

            return View(bodega);
        }

        // POST: Bodegas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bodega = await _context.Bodega.SingleOrDefaultAsync(m => m.BodegaId == id);
            _context.Bodega.Remove(bodega);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BodegaExists(int id)
        {
            return _context.Bodega.Any(e => e.BodegaId == id);
        }
    }
}
