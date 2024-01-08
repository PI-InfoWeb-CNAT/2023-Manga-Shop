using MangaShop.Data;
using MangaShop.ViewComponents;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MangaShop.Models
{
    public class CarrinhoCompra
    {
        private readonly BancoContext _bancoContext;
        public CarrinhoCompra(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public IList<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }
        public string CarrinhoCompraId { get; set; }
        public static CarrinhoCompra GetCarrinho(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;

            var context = service.GetService<BancoContext>();

            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();
            
            session.SetString("CarrinhoId", carrinhoId);

            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };
        }

        public void AdicionarItemNoCarrinho(ProductModel product)
        {
            var items = _bancoContext.CarrinhoCompraItens.
                FirstOrDefault(o => o.ProductModel.Id == product.Id && o.CarrinhoCompraId == CarrinhoCompraId);
            if (items == null) 
            {
                items = new CarrinhoCompraItem()
                {
                    ProductModel = product,
                    CarrinhoCompraId = CarrinhoCompraId
                };
                _bancoContext.CarrinhoCompraItens.Add(items);
            }
            _bancoContext.SaveChanges();
        }
        public void RemoverItemNoCarrinho(ProductModel product)
        {
            var items = _bancoContext.CarrinhoCompraItens.
                FirstOrDefault(o => o.ProductModel.Id == product.Id && o.CarrinhoCompraId == CarrinhoCompraId);
            if (items != null)
            {
                _bancoContext.CarrinhoCompraItens.Remove(items);
            }
            _bancoContext.SaveChanges();
        }
        public IList<CarrinhoCompraItem> GetCarrinhoCompraItems()
        {
            return CarrinhoCompraItems ?? (CarrinhoCompraItems = _bancoContext.CarrinhoCompraItens.
                Where(o => o.CarrinhoCompraId == CarrinhoCompraId).
                Include(o => o.ProductModel).
                ToList());
        }
        public void LimparCarrinho()
        {
            var clear = _bancoContext.CarrinhoCompraItens.Where(o => o.CarrinhoCompraId == CarrinhoCompraId);
            _bancoContext.CarrinhoCompraItens.RemoveRange(clear);
            _bancoContext.SaveChanges();
        }
        public decimal GetTotal()
        {
            var total = _bancoContext.CarrinhoCompraItens.Where(o => o.CarrinhoCompraId == CarrinhoCompraId).
                Select(o => o.ProductModel.Value).
                Sum();
            return total;
        }
    }
}
