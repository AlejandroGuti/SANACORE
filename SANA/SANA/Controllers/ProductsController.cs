using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SANA.Entities;
using SANA.Helpers;

namespace SANA.Controllers
{
    public class ProductsController : Controller
    {
        private readonly SANAContext _context;
        private readonly ICombosHelper _combosHelper;

        public ProductsController(SANAContext context, ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }
        public async Task<IActionResult> IndexMemory()
        {
            return View(/*await _context.Products.ToListAsync()*/);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p =>p.ProductsCategory)
                    .ThenInclude(pc => pc.FkIdCategoryNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            Products model = new Products
            {
                ProductCategoriesPicker = _combosHelper.GetComboCategories()
            };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Products product)
        {
            if (ModelState.IsValid)
            {

               

                switch (product.SaveAs)
                {
                    case 1:
                        MemoryCache.Instance.CurrentProduct= product  ;
                        return RedirectToAction(nameof(IndexMemory));
                       
                    case 2:
                        _context.Add(product);
                        foreach (int productCategory in product.ProductCategories)
                        {
                            ProductsCategory newProductCategory = new ProductsCategory
                            {
                                FkIdCategory = productCategory,
                                FkIdProducts = product.Id
                            };
                            _context.ProductsCategory.Add(newProductCategory);
                        }

                        await _context.SaveChangesAsync();


                        return RedirectToAction(nameof(Index));
                    default:
                        product.ProductCategoriesPicker = _combosHelper.GetComboCategories();
                        return View(product);
                }
                /* if (product.SaveAs == 1) {
                     MemoryCache.Instance.CurrentProduct = product;
                     return RedirectToAction(nameof(Index));
                 }
                 _context.Add(product);
                 foreach (int productCategory in product.ProductCategories)
                 {
                     ProductsCategory newProductCategory = new ProductsCategory
                     {
                         FkIdCategory = productCategory,
                         FkIdProducts = product.Id
                     };
                     _context.ProductsCategory.Add(newProductCategory);
                 }

                 await _context.SaveChangesAsync();


                 return RedirectToAction(nameof(Index));*/
            }
            product.ProductCategoriesPicker = _combosHelper.GetComboCategories();
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdProduct,Title,Description,Price")] Products products)
        {
            if (id != products.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.Id))
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
            return View(products);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var products = await _context.Products.FindAsync(id);
            _context.Products.Remove(products);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
        public async Task<IActionResult> ListCategory()
        {
            return View(await _context.Category.ToListAsync());
        }
    }
}
