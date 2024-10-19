using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Threading;
using WebAppMVC.Data;
using WebAppMVC.Migrations;
using WebAppMVC.Models;

public class ProductsController : Controller
{
    private readonly WebAppMVCContext _context;

    public ProductsController(WebAppMVCContext context)
    {
        _context = context;
    }

    // Route: /products
    [HttpGet("/products")]
    public async Task<IActionResult> Index()
    {
        var products = await _context.Product.Include(p => p.Category).ToListAsync();
        return View(products);
    }

    // Route: /product/{id}
    [HttpGet("/product/{id}")]
    public async Task<IActionResult> Details(int id)
    {
        var product = await _context.Product.Include(p => p.Category)
                                             .FirstOrDefaultAsync(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    public async Task<IActionResult> Create()
    {
        var categories = await _context.Category.ToListAsync();
        ViewBag.Categories = categories;
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(WebAppMVC.Models.Product product)
    {
        if (ModelState.IsValid)
        {
            _context.Add(product); 
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        var categories = await _context.Category.ToListAsync();
        ViewBag.Categories = categories;

        return View(product);
    }

    [HttpGet("/product/edit/{id}")]
    public async Task<IActionResult> Edit(int? Id)
    {
        if (Id == null)
        {
            return NotFound();
        }
        var product = await _context.Product.FindAsync(Id);
        if (product == null) {
            return NotFound();
        }
        var categories = await _context.Category.ToListAsync();
        ViewBag.Categories = categories;
        return View(product);
    }

    [HttpPost("/product/edit/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int Id, [Bind("Id, Title, Price, StockQuantity, CategoryId")] WebAppMVC.Models.Product product)
    {
        if (Id != product.Id)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("/product/delete/{id}")]
    public async Task<IActionResult> Delete(int? Id)
    {
        if (Id == null)
        {
            return NotFound();
        }

        var product = await _context.Product.FirstOrDefaultAsync(p => p.Id == Id);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    [HttpPost("/product/delete/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirm(int Id)
    {
        var product = await _context.Product.FindAsync(Id);
        if (product != null)
        {
           _context.Product.Remove(product);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ProductExists(int id) {
        return _context.Product.Any(Product => Product.Id == id);
    }
}
