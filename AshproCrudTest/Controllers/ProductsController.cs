using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AshproCrudTest.Models;
using AshproStringExtension;
namespace AshproCrudTest.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IRepository<Product> db;

        public ProductsController(IRepository<Product> _db)
        {
            db = _db;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
              return db.GetAll != null ? 
                          View(await db.GetAll()) :
                          Problem("Entity set 'AshproDBContext.Products'  is null.");
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null ||db.GetAll() == null)
            {
                return NotFound();
            }

            var product = await db.Get(id.toInt32());
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Price,Id")] Product product)
        {
            if (ModelState.IsValid)
            {
                await db.Add(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || db.GetAll() == null)
            {
                return NotFound();
            }

            var product = await db.Get(id.toInt32());
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,Price,Id")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   await db.Update(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ProductExists(product.Id))
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
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null ||db.GetAll() == null)
            {
                return NotFound();
            }

            var product = await db.Get(id.toInt32());
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await db.GetAll() == null)
            {
                return Problem("Entity set 'AshproDBContext.Products'  is null.");
            }
            var product = await db.Get(id.ToInt32());
            if (product != null)
            {
                await db.Delete(product);
            }
            return RedirectToAction(nameof(Index));
        }
        private async Task<bool> ProductExists(int id)
        {
            return await db.Get(id.ToInt32()) == null ? false : true;
        }
    }
}
