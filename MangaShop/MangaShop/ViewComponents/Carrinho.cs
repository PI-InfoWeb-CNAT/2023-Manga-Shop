using MangaShop.Models;
using MangaShop.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MangaShop.ViewComponents
{
    public class Carrinho : ViewComponent
    {
        private readonly IProductRepositorio _productRepositorio;

        public Carrinho(IProductRepositorio productRepositorio)
        {
            _productRepositorio = productRepositorio;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (HttpContext.Session.TryGetValue("LoggedUserSession", out byte[] userSessionBytes))
            {
                string userSession = System.Text.Encoding.UTF8.GetString(userSessionBytes);
                UserModel user = JsonConvert.DeserializeObject<UserModel>(userSession);

                if (user != null)
                {
                    var carrinhoList = _productRepositorio.GetProductsFromCart(user);

                    if (carrinhoList != null && carrinhoList.Count > 0)
                    {
                        return View(carrinhoList);
                    }
                    else
                    {
                        return View("Ghost");
                    }
                }
            }

            return View("Index", "Login");
        }
    }
}
