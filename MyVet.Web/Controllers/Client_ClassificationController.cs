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
    public class Client_ClassificationController : Controller
    {
        private readonly DataContext _context;

        public Client_ClassificationController(DataContext context)
        {
            _context = context;
        }

        // GET: Client_Classification
        public async Task<IActionResult> Index()
        {
            return View(await _context.Client_Classification.ToListAsync());
        }

        // GET: Client_Classification/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client_Classification = await _context.Client_Classification
                .FirstOrDefaultAsync(m => m.ClientClass_Id == id);
            if (client_Classification == null)
            {
                return NotFound();
            }

            return View(client_Classification);
        }

        // GET: Client_Classification/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Client_Classification/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientClass_Id,Classicifcation_Name")] Client_Classification client_Classification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(client_Classification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(client_Classification);
        }

        // GET: Client_Classification/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client_Classification = await _context.Client_Classification.FindAsync(id);
            if (client_Classification == null)
            {
                return NotFound();
            }
            return View(client_Classification);
        }

        // POST: Client_Classification/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientClass_Id,Classicifcation_Name")] Client_Classification client_Classification)
        {
            if (id != client_Classification.ClientClass_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client_Classification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Client_ClassificationExists(client_Classification.ClientClass_Id))
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
            return View(client_Classification);
        }

        // GET: Client_Classification/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client_Classification = await _context.Client_Classification
                .FirstOrDefaultAsync(m => m.ClientClass_Id == id);
            if (client_Classification == null)
            {
                return NotFound();
            }

            return View(client_Classification);
        }

        // POST: Client_Classification/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client_Classification = await _context.Client_Classification.FindAsync(id);
            _context.Client_Classification.Remove(client_Classification);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Client_ClassificationExists(int id)
        {
            return _context.Client_Classification.Any(e => e.ClientClass_Id == id);
        }
    }
}
