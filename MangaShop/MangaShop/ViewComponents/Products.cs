using MangaShop.Models;
using MangaShop.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MangaShop.ViewComponents
{
    public class Products : ViewComponent
    {
        private readonly IProductRepositorio _productRepositorio;

        public IProductRepositorio Get_productRepositorio()
        {
            return _productRepositorio;
        }

        public async Task<IViewComponentResult> InvokeAsync(IProductRepositorio productRepositorio, IProductRepositorio _productRepositorio)
        {
            _productRepositorio = productRepositorio;
            var userProducts = _productRepositorio.ListByUserId(1);
            return View(userProducts);
        }
    }
}
