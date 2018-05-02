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
    public class Proveedor_LotesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Proveedor_LotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Proveedor_Lotes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Proveedor_Lote.Include(p => p.Lotes).Include(p => p.Proveedores);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Proveedor_Lotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedor_Lote = await _context.Proveedor_Lote
                .Include(p => p.Lotes)
                .Include(p => p.Proveedores)
                .SingleOrDefaultAsync(m => m.Proveedor_LoteId == id);
            if (proveedor_Lote == null)
            {
                return NotFound();
            }

            return View(proveedor_Lote);
        }

        // GET: Proveedor_Lotes/Create
        public IActionResult Create()
        {
            ViewData["LoteId"] = new SelectList(_context.Lote, "LoteId", "Codigolote");
            ViewData["ProveedorId"] = new SelectList(_context.Proveedor, "ProveedorId", "Apellidos");
            return View();
        }

        // POST: Proveedor_Lotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Proveedor_LoteId,ProveedorId,LoteId")] Proveedor_Lote proveedor_Lote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proveedor_Lote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LoteId"] = new SelectList(_context.Lote, "LoteId", "Codigolote", proveedor_Lote.LoteId);
            ViewData["ProveedorId"] = new SelectList(_context.Proveedor, "ProveedorId", "Apellidos", proveedor_Lote.ProveedorId);
            return View(proveedor_Lote);
        }

        // GET: Proveedor_Lotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedor_Lote = await _context.Proveedor_Lote.SingleOrDefaultAsync(m => m.Proveedor_LoteId == id);
            if (proveedor_Lote == null)
            {
                return NotFound();
            }
            ViewData["LoteId"] = new SelectList(_context.Lote, "LoteId", "Codigolote", proveedor_Lote.LoteId);
            ViewData["ProveedorId"] = new SelectList(_context.Proveedor, "ProveedorId", "Apellidos", proveedor_Lote.ProveedorId);
            return View(proveedor_Lote);
        }

        // POST: Proveedor_Lotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Proveedor_LoteId,ProveedorId,LoteId")] Proveedor_Lote proveedor_Lote)
        {
            if (id != proveedor_Lote.Proveedor_LoteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proveedor_Lote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Proveedor_LoteExists(proveedor_Lote.Proveedor_LoteId))
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
            ViewData["LoteId"] = new SelectList(_context.Lote, "LoteId", "Codigolote", proveedor_Lote.LoteId);
            ViewData["ProveedorId"] = new SelectList(_context.Proveedor, "ProveedorId", "Apellidos", proveedor_Lote.ProveedorId);
            return View(proveedor_Lote);
        }

        // GET: Proveedor_Lotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedor_Lote = await _context.Proveedor_Lote
                .Include(p => p.Lotes)
                .Include(p => p.Proveedores)
                .SingleOrDefaultAsync(m => m.Proveedor_LoteId == id);
            if (proveedor_Lote == null)
            {
                return NotFound();
            }

            return View(proveedor_Lote);
        }

        // POST: Proveedor_Lotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proveedor_Lote = await _context.Proveedor_Lote.SingleOrDefaultAsync(m => m.Proveedor_LoteId == id);
            _context.Proveedor_Lote.Remove(proveedor_Lote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Proveedor_LoteExists(int id)
        {
            return _context.Proveedor_Lote.Any(e => e.Proveedor_LoteId == id);
        }
    }
}
