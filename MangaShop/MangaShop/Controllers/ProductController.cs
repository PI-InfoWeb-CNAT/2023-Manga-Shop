using Microsoft.AspNetCore.Mvc;
using MangaShop.Models;
using MangaShop.Repositorio;

namespace MangaShop.Controllers
{
    public class ProductController : Controller
    {
        // User Repositorio
        private readonly IProductRepositorio _productRepositorio;
        public ProductController(IProductRepositorio ProductRepositorio)
        {
            _productRepositorio = ProductRepositorio;
        }
        public IActionResult Index(int id)
        {
            ProductModel product = _productRepositorio.ListByid(id);
            return View("Index", product);
        }
    }
}
