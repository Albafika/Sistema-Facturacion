﻿using System;
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
    public class NeighborhoodsController : Controller
    {
        private readonly DataContext _context;

        public NeighborhoodsController(DataContext context)
        {
            _context = context;
        }

        // GET: Neighborhoods
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Neighborhood.Include(n => n.City);
            return View(await dataContext.ToListAsync());
        }

        // GET: Neighborhoods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neighborhood = await _context.Neighborhood
                .Include(n => n.City)
                .FirstOrDefaultAsync(m => m.Neighborhood_Id == id);
            if (neighborhood == null)
            {
                return NotFound();
            }

            return View(neighborhood);
        }

        // GET: Neighborhoods/Create
        public IActionResult Create()
        {
            ViewData["City_Id"] = new SelectList(_context.City, "City_Id", "City_Name");
            return View();
        }

        // POST: Neighborhoods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Neighborhood_Id,Neighborhood_Name,City_Id")] Neighborhood neighborhood)
        {
            if (ModelState.IsValid)
            {
                _context.Add(neighborhood);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["City_Id"] = new SelectList(_context.City, "City_Id", "City_Name", neighborhood.City_Id);
            return View(neighborhood);
        }

        // GET: Neighborhoods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neighborhood = await _context.Neighborhood.FindAsync(id);
            if (neighborhood == null)
            {
                return NotFound();
            }
            ViewData["City_Id"] = new SelectList(_context.City, "City_Id", "City_Name", neighborhood.City_Id);
            return View(neighborhood);
        }

        // POST: Neighborhoods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Neighborhood_Id,Neighborhood_Name,City_Id")] Neighborhood neighborhood)
        {
            if (id != neighborhood.Neighborhood_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(neighborhood);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NeighborhoodExists(neighborhood.Neighborhood_Id))
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
            ViewData["City_Id"] = new SelectList(_context.City, "City_Id", "City_Name", neighborhood.City_Id);
            return View(neighborhood);
        }

        // GET: Neighborhoods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neighborhood = await _context.Neighborhood
                .Include(n => n.City)
                .FirstOrDefaultAsync(m => m.Neighborhood_Id == id);
            if (neighborhood == null)
            {
                return NotFound();
            }

            return View(neighborhood);
        }

        // POST: Neighborhoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var neighborhood = await _context.Neighborhood.FindAsync(id);
            _context.Neighborhood.Remove(neighborhood);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NeighborhoodExists(int id)
        {
            return _context.Neighborhood.Any(e => e.Neighborhood_Id == id);
        }
    }
}
