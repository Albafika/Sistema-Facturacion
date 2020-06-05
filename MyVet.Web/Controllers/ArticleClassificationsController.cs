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
    public class ArticleClassificationsController : Controller
    {
        private readonly DataContext _context;

        public ArticleClassificationsController(DataContext context)
        {
            _context = context;
        }

        // GET: ArticleClassifications
        public async Task<IActionResult> Index()
        {
            return View(await _context.ArticleClassification.ToListAsync());
        }

        // GET: ArticleClassifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleClassification = await _context.ArticleClassification
                .FirstOrDefaultAsync(m => m.ArtC_Id == id);
            if (articleClassification == null)
            {
                return NotFound();
            }

            return View(articleClassification);
        }

        // GET: ArticleClassifications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArticleClassifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArtC_Id,Codigo,Name_ArtC")] ArticleClassification articleClassification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articleClassification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(articleClassification);
        }

        // GET: ArticleClassifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleClassification = await _context.ArticleClassification.FindAsync(id);
            if (articleClassification == null)
            {
                return NotFound();
            }
            return View(articleClassification);
        }

        // POST: ArticleClassifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArtC_Id,Codigo,Name_ArtC")] ArticleClassification articleClassification)
        {
            if (id != articleClassification.ArtC_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articleClassification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleClassificationExists(articleClassification.ArtC_Id))
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
            return View(articleClassification);
        }

        // GET: ArticleClassifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleClassification = await _context.ArticleClassification
                .FirstOrDefaultAsync(m => m.ArtC_Id == id);
            if (articleClassification == null)
            {
                return NotFound();
            }

            return View(articleClassification);
        }

        // POST: ArticleClassifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articleClassification = await _context.ArticleClassification.FindAsync(id);
            _context.ArticleClassification.Remove(articleClassification);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleClassificationExists(int id)
        {
            return _context.ArticleClassification.Any(e => e.ArtC_Id == id);
        }
    }
}
