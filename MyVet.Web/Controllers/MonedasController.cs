using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sistema.Web.Data;
using Sistema.Web.Data.Entities;

namespace Sistema.Web.Controllers
{
    public class MonedasController : Controller
    {
        private readonly DataContext _context;

        public MonedasController(DataContext context)
        {
            _context = context;
        }

        // GET: Monedas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Moneda.ToListAsync());
        }

        // GET: Monedas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moneda = await _context.Moneda
                .FirstOrDefaultAsync(m => m.Moneda_Id == id);
            if (moneda == null)
            {
                return NotFound();
            }

            return View(moneda);
        }

        // GET: Monedas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Monedas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Moneda_Id,Name_moneda,Tasa_moneda,Nmoneda")] Moneda moneda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moneda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(moneda);
        }

        // GET: Monedas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moneda = await _context.Moneda.FindAsync(id);
            if (moneda == null)
            {
                return NotFound();
            }
            return View(moneda);
        }

        // POST: Monedas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Moneda_Id,Name_moneda,Tasa_moneda,Nmoneda")] Moneda moneda)
        {
            if (id != moneda.Moneda_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moneda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonedaExists(moneda.Moneda_Id))
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
            return View(moneda);
        }

        // GET: Monedas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moneda = await _context.Moneda
                .FirstOrDefaultAsync(m => m.Moneda_Id == id);
            if (moneda == null)
            {
                return NotFound();
            }

            return View(moneda);
        }

        // POST: Monedas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moneda = await _context.Moneda.FindAsync(id);
            _context.Moneda.Remove(moneda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonedaExists(int id)
        {
            return _context.Moneda.Any(e => e.Moneda_Id == id);
        }
    }
}
