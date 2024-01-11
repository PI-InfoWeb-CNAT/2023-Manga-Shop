using MangaShop.Data;
using MangaShop.Helper;
using MangaShop.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace MangaShop.Repositorio
{
    public class ProductRepositorio : IProductRepositorio
    {
        private readonly BancoContext _bancoContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ISessao _sessao;


        public ProductRepositorio(BancoContext bancoContext, IWebHostEnvironment webHost, ISessao sessao)
        {
            _bancoContext = bancoContext;
            webHostEnvironment = webHost;
            _sessao = sessao;
        }
        public ProductModel ListByid(int id)
        {
            return _bancoContext.Products.FirstOrDefault(x => x.ProductId == id);
        }

        public List<ProductModel> GetProductsFromCart(UserModel user)
        {
            // Certifique-se de que User.Carrinho seja uma lista de CartItem
            var productIds = user.Carrinho.Select(ci => ci.ProductId).ToList();

            return _bancoContext.Products.Where(p => productIds.Contains(p.ProductId)).ToList();
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
        public ProductModel Adicionar(ProductModel product, string userSession)
        {
            string uniqueFileName = UploadedFile(product);
            UserModel user = JsonConvert.DeserializeObject<UserModel>(userSession);
            // gravar no banco
            product.UserId = user.UserId;
            _bancoContext.Products.Add(product);
            _bancoContext.SaveChanges();
            product.ImagePath = uniqueFileName;
            _bancoContext.Products.Update(product);
            _bancoContext.SaveChanges();

            return product;
        }
        public ProductModel Editar(ProductModel product)
        {
            ProductModel productDB = ListByid(product.ProductId);
            string uniqueFileName = UploadedFile(product);
            if (productDB == null) throw new System.Exception("usuario nao existe no sistema!");

            productDB.Title = product.Title;
            productDB.Value = product.Value;
            productDB.Description = product.Description;
            product.ImagePath = uniqueFileName;


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

        private string UploadedFile(ProductModel product)
        {
            string uniqueFileName = null;

            if (product.Image != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "imagens");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + product.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    product.Image.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
