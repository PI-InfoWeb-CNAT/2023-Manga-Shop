using MangaShop.Models;
using MangaShop.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MangaShop.ViewComponents
{
    public class Products : ViewComponent
    {
        private readonly IProductRepositorio _productRepositorio;
        

        public Products (IProductRepositorio productRepositorio)
        {
            _productRepositorio = productRepositorio;
        }
        private List<ProductModel> productList = new List<ProductModel>();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string userSession = HttpContext.Session.GetString("LoggedUserSession");
            
            UserModel user = JsonConvert.DeserializeObject<UserModel>(userSession);
            if (string.IsNullOrEmpty(userSession))
            {
                return View("Index", "Login");
            }



            var userProducts = _productRepositorio.ListByUserId(user.Id);

            productList.AddRange(userProducts);

            if (userProducts == null)
            {
                return View("Ghost");
            }

            
                return View(userProducts);
            
        }
    }
}
