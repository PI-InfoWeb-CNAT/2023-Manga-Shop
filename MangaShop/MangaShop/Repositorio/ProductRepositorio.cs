using MangaShop.Data;
using MangaShop.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MangaShop.Repositorio
{
    public class ProductRepositorio : IProductRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ProductRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public ProductModel ListByid(int id)
        {
            return _bancoContext.Products.FirstOrDefault(x => x.Id == id);
        }
        public List<ProductModel> ListByUserId(int userId)
        {
            var products = _bancoContext.Products.Where(x => x.UserId == userId).ToList();
            return products;
        }
        public List<ProductModel> ListarTodos()
        {
            return _bancoContext.Products.ToList();
        }
        public ProductModel Adicionar(ProductModel product)
        {
            // gravar no banco
            _bancoContext.Products.Add(product);
            _bancoContext.SaveChanges();
            return product;
        }

       

        public ProductModel Editar(ProductModel product)
        {
            ProductModel productDB = ListByid(product.Id);

            if (productDB == null) throw new System.Exception("usuario nao existe no sistema!");

            productDB.Title = product.Title;
            // userDB.Email = user.Email;
            productDB.Value = product.Value;
            // userDB.Password = user.Password;
            productDB.Description = product.Description;
            
            _bancoContext.Products.Update(productDB);
            _bancoContext.SaveChanges();
            return productDB;  

        }

        public bool Deletar(int id)
        {
            ProductModel productDB = ListByid(id);
            if (productDB == null) throw new System.Exception("Ocorreu um erro ao excluir sua conta!");

            _bancoContext.Products.Remove(productDB);
            _bancoContext.SaveChanges();
            return true;
        }

        public ProductModel GetByValue(int value)
        {
            return _bancoContext.Products.FirstOrDefault(x => x.Value == value);   
        }
    }
}
