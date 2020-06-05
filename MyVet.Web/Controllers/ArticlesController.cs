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
    public class ArticlesController : Controller
    {
        private readonly DataContext _context;

        public ArticlesController(DataContext context)
        {
            _context = context;
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Article.Include(a => a.ArticleClassification).Include(a => a.Brand);
            return View(await dataContext.ToListAsync());
        }

        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Article
                .Include(a => a.ArticleClassification)
                .Include(a => a.Brand)
                .FirstOrDefaultAsync(m => m.Article_Id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // GET: Articles/Create
        public IActionResult Create()
        {
            ViewData["ArtC_Id"] = new SelectList(_context.ArticleClassification, "ArtC_Id", "Codigo");
            ViewData["Brand_Id"] = new SelectList(_context.Brand, "Brand_Id", "Brand_Name");
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Article_Id,Article_Name,ArtC_Id,Brand_Id")] Article article)
        {
            if (ModelState.IsValid)
            {
                _context.Add(article);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtC_Id"] = new SelectList(_context.ArticleClassification, "ArtC_Id", "Codigo", article.ArtC_Id);
            ViewData["Brand_Id"] = new SelectList(_context.Brand, "Brand_Id", "Brand_Name", article.Brand_Id);
            return View(article);
        }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Article.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            ViewData["ArtC_Id"] = new SelectList(_context.ArticleClassification, "ArtC_Id", "Codigo", article.ArtC_Id);
            ViewData["Brand_Id"] = new SelectList(_context.Brand, "Brand_Id", "Brand_Name", article.Brand_Id);
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Article_Id,Article_Name,ArtC_Id,Brand_Id")] Article article)
        {
            if (id != article.Article_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(article);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.Article_Id))
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
            ViewData["ArtC_Id"] = new SelectList(_context.ArticleClassification, "ArtC_Id", "Codigo", article.ArtC_Id);
            ViewData["Brand_Id"] = new SelectList(_context.Brand, "Brand_Id", "Brand_Name", article.Brand_Id);
            return View(article);
        }

        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Article
                .Include(a => a.ArticleClassification)
                .Include(a => a.Brand)
                .FirstOrDefaultAsync(m => m.Article_Id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var article = await _context.Article.FindAsync(id);
            _context.Article.Remove(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return _context.Article.Any(e => e.Article_Id == id);
        }
    }
}
