using AspNetCore;
using MangaShop.Models;
using MangaShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MangaShop.ViewComponents
{
    public class CarrinhoCompraResumo : ViewComponent
    {
        private readonly CarrinhoCompra _carrinhoCompra;
        public CarrinhoCompraResumo(CarrinhoCompra carrinhoCompra)
        {
            _carrinhoCompra = carrinhoCompra;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItems();
            _carrinhoCompra.CarrinhoCompraItems = itens;

            var carrinhoVw = new CarrinhoCompraVw()
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoTotal = _carrinhoCompra.GetTotal()
            };
            return View(carrinhoVw);
        }
    }
}
