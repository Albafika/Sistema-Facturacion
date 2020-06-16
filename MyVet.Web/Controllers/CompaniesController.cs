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
    public class CompaniesController : Controller
    {
        private readonly DataContext _context;

        public CompaniesController(DataContext context)
        {
            _context = context;
        }

        // GET: Companies
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Company.Include(c => c.Company_Classification).Include(c => c.Document).Include(c => c.Neighborhood);
            return View(await dataContext.ToListAsync());
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company
                .Include(c => c.Company_Classification)
                .Include(c => c.Document)
                .Include(c => c.Neighborhood)
                .FirstOrDefaultAsync(m => m.Company_Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            ViewData["CompanyClass_Id"] = new SelectList(_context.Company_Classification, "CompanyClass_Id", "CompanyClass_Name");
            ViewData["Document_Id"] = new SelectList(_context.Document, "Document_Id", "Documento");
            ViewData["Neighborhood_Id"] = new SelectList(_context.Neighborhood, "Neighborhood_Id", "Neighborhood_Name");
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Company_Id,Company_Name,CompanyClass_Id,Document_Id,Document_Code,Direccion,Neighborhood_Id,correo,phone")] Company company)
        {
            if (ModelState.IsValid)
            {
                _context.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyClass_Id"] = new SelectList(_context.Company_Classification, "CompanyClass_Id", "CompanyClass_Name", company.CompanyClass_Id);
            ViewData["Document_Id"] = new SelectList(_context.Document, "Document_Id", "Documento", company.Document_Id);
            ViewData["Neighborhood_Id"] = new SelectList(_context.Neighborhood, "Neighborhood_Id", "Neighborhood_Name", company.Neighborhood_Id);
            return View(company);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            ViewData["CompanyClass_Id"] = new SelectList(_context.Company_Classification, "CompanyClass_Id", "CompanyClass_Name", company.CompanyClass_Id);
            ViewData["Document_Id"] = new SelectList(_context.Document, "Document_Id", "Documento", company.Document_Id);
            ViewData["Neighborhood_Id"] = new SelectList(_context.Neighborhood, "Neighborhood_Id", "Neighborhood_Name", company.Neighborhood_Id);
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Company_Id,Company_Name,CompanyClass_Id,Document_Id,Document_Code,Direccion,Neighborhood_Id,correo,phone")] Company company)
        {
            if (id != company.Company_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.Company_Id))
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
            ViewData["CompanyClass_Id"] = new SelectList(_context.Company_Classification, "CompanyClass_Id", "CompanyClass_Name", company.CompanyClass_Id);
            ViewData["Document_Id"] = new SelectList(_context.Document, "Document_Id", "Documento", company.Document_Id);
            ViewData["Neighborhood_Id"] = new SelectList(_context.Neighborhood, "Neighborhood_Id", "Neighborhood_Name", company.Neighborhood_Id);
            return View(company);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company
                .Include(c => c.Company_Classification)
                .Include(c => c.Document)
                .Include(c => c.Neighborhood)
                .FirstOrDefaultAsync(m => m.Company_Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var company = await _context.Company.FindAsync(id);
            _context.Company.Remove(company);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
            return _context.Company.Any(e => e.Company_Id == id);
        }
    }
}
