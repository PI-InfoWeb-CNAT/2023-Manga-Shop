using MangaShop.Models;
using MangaShop.Repositorio;
using MangaShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MangaShop.Controllers
{
    public class CarrinhoComprasController : Controller
    {
        private readonly IProductRepositorio _productRepositorio;
        private readonly CarrinhoCompra _carrinhoCompra;
        public CarrinhoComprasController(IProductRepositorio productRepositorio, CarrinhoCompra carrinhoCompra)
        {
            _productRepositorio = productRepositorio;
            _carrinhoCompra = carrinhoCompra;
        }
        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItems();
            _carrinhoCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraVw = new CarrinhoCompraVw()
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoTotal = _carrinhoCompra.GetTotal()
            };
            return View(carrinhoCompraVw);
        }

        public IActionResult AdicionarItem(int id)
        {
            var carrinho = _productRepositorio.ListByid(id);
            if (carrinho != null)
            {
                _carrinhoCompra.AdicionarItemNoCarrinho(carrinho);
            }
            return RedirectToAction("Index");
        }
        public IActionResult RemoverItem(int id)
        {
            var carrinho = _productRepositorio.ListByid(id);
            if (carrinho != null)
            {
                _carrinhoCompra.RemoverItemNoCarrinho(carrinho);
            }
            return RedirectToAction("Index");
        }
    }
}
