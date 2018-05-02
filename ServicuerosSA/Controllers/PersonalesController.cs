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
    public class PersonalesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Personales
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Personal.Include(p => p.Sexo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Personales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personal = await _context.Personal
                .Include(p => p.Sexo)
                .SingleOrDefaultAsync(m => m.PersonalId == id);
            if (personal == null)
            {
                return NotFound();
            }

            return View(personal);
        }

        // GET: Personales/Create
        public IActionResult Create()
        {
            ViewData["SexoId"] = new SelectList(_context.Set<Sexo>(), "SexoId", "Detalle");
            return View();
        }

        // POST: Personales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonalId,Cedula,Nombres,Apellidos,FechaNacimiento,SexoId,Telefono,Celular,Direccion")] Personal personal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SexoId"] = new SelectList(_context.Set<Sexo>(), "SexoId", "SexoId", personal.SexoId);
            return View(personal);
        }

        // GET: Personales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personal = await _context.Personal.SingleOrDefaultAsync(m => m.PersonalId == id);
            if (personal == null)
            {
                return NotFound();
            }
            ViewData["SexoId"] = new SelectList(_context.Set<Sexo>(), "SexoId", "SexoId", personal.SexoId);
            return View(personal);
        }

        // POST: Personales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonalId,Cedula,Nombres,Apellidos,FechaNacimiento,SexoId,Telefono,Celular,Direccion")] Personal personal)
        {
            if (id != personal.PersonalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalExists(personal.PersonalId))
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
            ViewData["SexoId"] = new SelectList(_context.Set<Sexo>(), "SexoId", "SexoId", personal.SexoId);
            return View(personal);
        }

        // GET: Personales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personal = await _context.Personal
                .Include(p => p.Sexo)
                .SingleOrDefaultAsync(m => m.PersonalId == id);
            if (personal == null)
            {
                return NotFound();
            }

            return View(personal);
        }

        // POST: Personales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personal = await _context.Personal.SingleOrDefaultAsync(m => m.PersonalId == id);
            _context.Personal.Remove(personal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalExists(int id)
        {
            return _context.Personal.Any(e => e.PersonalId == id);
        }
    }
}
