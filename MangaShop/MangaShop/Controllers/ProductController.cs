using Microsoft.AspNetCore.Mvc;
using MangaShop.Models;

namespace MangaShop.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(ProductModel product, UserModel user)
        {
            ViewBag.User = user;
            return View(product);
        }
    }
}
