using Microsoft.AspNetCore.Mvc;
using MangaShop.Models;

namespace MangaShop.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(ProductModel product)
        {
            return View(product);
        }
    }
}
