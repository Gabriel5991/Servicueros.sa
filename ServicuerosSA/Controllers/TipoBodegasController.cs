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
    public class TipoBodegasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoBodegasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoBodegas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoBodega.ToListAsync());
        }

        // GET: TipoBodegas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoBodega = await _context.TipoBodega
                .SingleOrDefaultAsync(m => m.TipoBodegaId == id);
            if (tipoBodega == null)
            {
                return NotFound();
            }

            return View(tipoBodega);
        }

        // GET: TipoBodegas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoBodegas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoBodegaId,Detalle")] TipoBodega tipoBodega)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoBodega);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoBodega);
        }

        // GET: TipoBodegas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoBodega = await _context.TipoBodega.SingleOrDefaultAsync(m => m.TipoBodegaId == id);
            if (tipoBodega == null)
            {
                return NotFound();
            }
            return View(tipoBodega);
        }

        // POST: TipoBodegas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoBodegaId,Detalle")] TipoBodega tipoBodega)
        {
            if (id != tipoBodega.TipoBodegaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoBodega);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoBodegaExists(tipoBodega.TipoBodegaId))
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
            return View(tipoBodega);
        }

        // GET: TipoBodegas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoBodega = await _context.TipoBodega
                .SingleOrDefaultAsync(m => m.TipoBodegaId == id);
            if (tipoBodega == null)
            {
                return NotFound();
            }

            return View(tipoBodega);
        }

        // POST: TipoBodegas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoBodega = await _context.TipoBodega.SingleOrDefaultAsync(m => m.TipoBodegaId == id);
            _context.TipoBodega.Remove(tipoBodega);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoBodegaExists(int id)
        {
            return _context.TipoBodega.Any(e => e.TipoBodegaId == id);
        }
    }
}
