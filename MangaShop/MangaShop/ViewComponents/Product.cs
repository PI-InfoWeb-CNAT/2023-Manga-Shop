using MangaShop.Models;
using MangaShop.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MangaShop.ViewComponents
{
    public class Product : ViewComponent
    {
        private readonly IProductRepositorio _productRepositorio;

        public Product (IProductRepositorio productRepositorio)
        {
            _productRepositorio = productRepositorio;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            string userSession = HttpContext.Session.GetString("LoggedUserSession");

            UserModel user = JsonConvert.DeserializeObject<UserModel>(userSession);

            int id = user.Id;

            ProductModel userProducts = _productRepositorio.ListByid(id);

            

            
                return View(userProducts);
            
        }
    }
}
