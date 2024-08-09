using Microsoft.AspNetCore.Mvc;
using ProgramaIAGPT.Models;

namespace ProgramaIAGPT.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> _products = new List<Product>();
        private static int nextId = 1;

        public IActionResult Index()
        {
            return View(_products);
        }

        public IActionResult Details(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.Id = nextId++;
                _products.Add(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
    }
}
