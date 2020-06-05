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
    public class FormPagoesController : Controller
    {
        private readonly DataContext _context;

        public FormPagoesController(DataContext context)
        {
            _context = context;
        }

        // GET: FormPagoes
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.FormPago.Include(f => f.Moneda);
            return View(await dataContext.ToListAsync());
        }

        // GET: FormPagoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formPago = await _context.FormPago
                .Include(f => f.Moneda)
                .FirstOrDefaultAsync(m => m.Id_Pago == id);
            if (formPago == null)
            {
                return NotFound();
            }

            return View(formPago);
        }

        // GET: FormPagoes/Create
        public IActionResult Create()
        {
            ViewData["Moneda_Id"] = new SelectList(_context.Moneda, "Moneda_Id", "Name_moneda");
            return View();
        }

        // POST: FormPagoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Pago,pago_Name,Moneda_Id")] FormPago formPago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formPago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Moneda_Id"] = new SelectList(_context.Moneda, "Moneda_Id", "Name_moneda", formPago.Moneda_Id);
            return View(formPago);
        }

        // GET: FormPagoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formPago = await _context.FormPago.FindAsync(id);
            if (formPago == null)
            {
                return NotFound();
            }
            ViewData["Moneda_Id"] = new SelectList(_context.Moneda, "Moneda_Id", "Name_moneda", formPago.Moneda_Id);
            return View(formPago);
        }

        // POST: FormPagoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Pago,pago_Name,Moneda_Id")] FormPago formPago)
        {
            if (id != formPago.Id_Pago)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formPago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormPagoExists(formPago.Id_Pago))
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
            ViewData["Moneda_Id"] = new SelectList(_context.Moneda, "Moneda_Id", "Name_moneda", formPago.Moneda_Id);
            return View(formPago);
        }

        // GET: FormPagoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formPago = await _context.FormPago
                .Include(f => f.Moneda)
                .FirstOrDefaultAsync(m => m.Id_Pago == id);
            if (formPago == null)
            {
                return NotFound();
            }

            return View(formPago);
        }

        // POST: FormPagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formPago = await _context.FormPago.FindAsync(id);
            _context.FormPago.Remove(formPago);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormPagoExists(int id)
        {
            return _context.FormPago.Any(e => e.Id_Pago == id);
        }
    }
}
