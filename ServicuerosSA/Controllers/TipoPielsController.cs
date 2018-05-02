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
    public class TipoPielsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoPielsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoPiels
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoPiel.ToListAsync());
        }

        // GET: TipoPiels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPiel = await _context.TipoPiel
                .SingleOrDefaultAsync(m => m.TipoPielId == id);
            if (tipoPiel == null)
            {
                return NotFound();
            }

            return View(tipoPiel);
        }

        // GET: TipoPiels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoPiels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoPielId,Detalle")] TipoPiel tipoPiel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoPiel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoPiel);
        }

        // GET: TipoPiels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPiel = await _context.TipoPiel.SingleOrDefaultAsync(m => m.TipoPielId == id);
            if (tipoPiel == null)
            {
                return NotFound();
            }
            return View(tipoPiel);
        }

        // POST: TipoPiels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoPielId,Detalle")] TipoPiel tipoPiel)
        {
            if (id != tipoPiel.TipoPielId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoPiel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoPielExists(tipoPiel.TipoPielId))
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
            return View(tipoPiel);
        }

        // GET: TipoPiels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPiel = await _context.TipoPiel
                .SingleOrDefaultAsync(m => m.TipoPielId == id);
            if (tipoPiel == null)
            {
                return NotFound();
            }

            return View(tipoPiel);
        }

        // POST: TipoPiels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoPiel = await _context.TipoPiel.SingleOrDefaultAsync(m => m.TipoPielId == id);
            _context.TipoPiel.Remove(tipoPiel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoPielExists(int id)
        {
            return _context.TipoPiel.Any(e => e.TipoPielId == id);
        }
    }
}
