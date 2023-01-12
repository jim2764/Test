using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using Test.Models;
using Test.Models.VMs;

namespace Test.Controllers
{
    public class ProductsController : Controller
    {
        private readonly BigProjectContext _context;

        public ProductsController(BigProjectContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.Include(x => x.ProductPhotos).ToListAsync());
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
        public async Task<IActionResult> Create(ProductVM vm)
        {
            // 建立商品的Entity
            // product變數為商品的Entity
            Product product = new Product()
            {
                Id = vm.Id,
                Name = vm.Name,
                Price = vm.Price,
                Inventory = vm.Inventory,
            };
            
            // 將image加入商品的Enity當中
            product.ProductPhotos.AddRange(vm.ProductPhotos.Select(x => new ProductPhoto()
            {
                Source = x.FileName,
            }));

            if (ModelState.IsValid)
            {
                // 將商品的Entity加入DB中
                _context.Add(product);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(vm);
        }
    }
}
