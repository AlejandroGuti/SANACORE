using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SANA.Entities;

namespace SANA.Controllers
{
    public class ProductsCategoriesController : Controller
    {
        private readonly SANAContext _context;

        public ProductsCategoriesController(SANAContext context)
        {
            _context = context;
        }

        // GET: ProductsCategories
        public async Task<IActionResult> Index()
        {
            var sANAContext = _context.ProductsCategory.Include(p => p.FkIdCategoryNavigation).Include(p => p.FkIdProductsNavigation);
            return View(await sANAContext.ToListAsync());
        }

        // GET: ProductsCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productsCategory = await _context.ProductsCategory
                .Include(p => p.FkIdCategoryNavigation)
                .Include(p => p.FkIdProductsNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productsCategory == null)
            {
                return NotFound();
            }

            return View(productsCategory);
        }

        // GET: ProductsCategories/Create
        public IActionResult Create()
        {
            ViewData["FkIdCategory"] = new SelectList(_context.Category, "Id", "Description");
            ViewData["FkIdProducts"] = new SelectList(_context.Products, "Id", "Description");
            return View();
        }

        // POST: ProductsCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FkIdProducts,FkIdCategory")] ProductsCategory productsCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productsCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkIdCategory"] = new SelectList(_context.Category, "Id", "Description", productsCategory.FkIdCategory);
            ViewData["FkIdProducts"] = new SelectList(_context.Products, "Id", "Description", productsCategory.FkIdProducts);
            return View(productsCategory);
        }

        // GET: ProductsCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productsCategory = await _context.ProductsCategory.FindAsync(id);
            if (productsCategory == null)
            {
                return NotFound();
            }
            ViewData["FkIdCategory"] = new SelectList(_context.Category, "Id", "Description", productsCategory.FkIdCategory);
            ViewData["FkIdProducts"] = new SelectList(_context.Products, "Id", "Description", productsCategory.FkIdProducts);
            return View(productsCategory);
        }

        // POST: ProductsCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FkIdProducts,FkIdCategory")] ProductsCategory productsCategory)
        {
            if (id != productsCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productsCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsCategoryExists(productsCategory.Id))
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
            ViewData["FkIdCategory"] = new SelectList(_context.Category, "Id", "Description", productsCategory.FkIdCategory);
            ViewData["FkIdProducts"] = new SelectList(_context.Products, "Id", "Description", productsCategory.FkIdProducts);
            return View(productsCategory);
        }

        // GET: ProductsCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productsCategory = await _context.ProductsCategory
                .Include(p => p.FkIdCategoryNavigation)
                .Include(p => p.FkIdProductsNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productsCategory == null)
            {
                return NotFound();
            }

            return View(productsCategory);
        }

        // POST: ProductsCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productsCategory = await _context.ProductsCategory.FindAsync(id);
            _context.ProductsCategory.Remove(productsCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsCategoryExists(int id)
        {
            return _context.ProductsCategory.Any(e => e.Id == id);
        }
    }
}
