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
    public class Company_ClassificationController : Controller
    {
        private readonly DataContext _context;

        public Company_ClassificationController(DataContext context)
        {
            _context = context;
        }

        // GET: Company_Classification
        public async Task<IActionResult> Index()
        {
            return View(await _context.Company_Classification.ToListAsync());
        }

        // GET: Company_Classification/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company_Classification = await _context.Company_Classification
                .FirstOrDefaultAsync(m => m.CompanyClass_Id == id);
            if (company_Classification == null)
            {
                return NotFound();
            }

            return View(company_Classification);
        }

        // GET: Company_Classification/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Company_Classification/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyClass_Id,CompanyClass_Name")] Company_Classification company_Classification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(company_Classification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(company_Classification);
        }

        // GET: Company_Classification/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company_Classification = await _context.Company_Classification.FindAsync(id);
            if (company_Classification == null)
            {
                return NotFound();
            }
            return View(company_Classification);
        }

        // POST: Company_Classification/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompanyClass_Id,CompanyClass_Name")] Company_Classification company_Classification)
        {
            if (id != company_Classification.CompanyClass_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company_Classification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Company_ClassificationExists(company_Classification.CompanyClass_Id))
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
            return View(company_Classification);
        }

        // GET: Company_Classification/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company_Classification = await _context.Company_Classification
                .FirstOrDefaultAsync(m => m.CompanyClass_Id == id);
            if (company_Classification == null)
            {
                return NotFound();
            }

            return View(company_Classification);
        }

        // POST: Company_Classification/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var company_Classification = await _context.Company_Classification.FindAsync(id);
            _context.Company_Classification.Remove(company_Classification);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Company_ClassificationExists(int id)
        {
            return _context.Company_Classification.Any(e => e.CompanyClass_Id == id);
        }
    }
}
