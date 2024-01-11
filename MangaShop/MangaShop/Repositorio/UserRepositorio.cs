using MangaShop.Data;
using MangaShop.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MangaShop.Repositorio
{
    public class UserRepositorio : IUserRepositorio
    {
        private readonly BancoContext _bancoContext;
        private readonly IWebHostEnvironment webHostEnvironment;
  
        public UserRepositorio(BancoContext bancoContext, IWebHostEnvironment webHost)
        {
            _bancoContext = bancoContext;
            webHostEnvironment = webHost;
        }
        public UserModel ListByid(int id)
        {
            return _bancoContext.Users.FirstOrDefault(x => x.UserId == id);
        }
        public List<UserModel> ListarTodos()
        {
            return _bancoContext.Users.ToList();
        }
        public UserModel Adicionar(UserModel user)
        {
            // gravar no banco
            _bancoContext.Users.Add(user);
            _bancoContext.SaveChanges();
            return user;
        }

        public UserModel Editar(UserModel user)
        {
            UserModel userDB = ListByid(user.UserId);

            if (userDB == null) throw new System.Exception("usuario nao existe no sistema!");

            string uniqueFileName = UploadedFile(user);


            userDB.Name = user.Name;
            // userDB.Email = user.Email;
            userDB.Cpf = user.Cpf;
            // userDB.Password = user.Password;
            userDB.Campus = user.Campus;
            userDB.Curso = user.Curso;
            userDB.PhoneNumber = user.PhoneNumber;
            userDB.IconPath = uniqueFileName;


            _bancoContext.Users.Update(userDB);
            _bancoContext.SaveChanges();
            return userDB;  

        }

        public bool Deletar(int id)
        {
            UserModel userDB = ListByid(id);
            if (userDB == null) throw new System.Exception("Ocorreu um erro ao excluir sua conta!");

            _bancoContext.Users.Remove(userDB);
            _bancoContext.SaveChanges();
            return true;
        }

        public UserModel GetByEmail(string email)
        {
            return _bancoContext.Users.FirstOrDefault(x => x.Email == email);   
    
        }
        private string UploadedFile(UserModel user)
        {
            string uniqueFileName = null;

            if (user.Icon != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "imagens");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + user.Icon.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    user.Icon.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        public void AdicionarProdutoAoCarrinho(int userId, int productId)
        {
            var user = _bancoContext.Users.Include(u => u.Carrinho).FirstOrDefault(u => u.UserId == userId);
            var product = _bancoContext.Products.FirstOrDefault(p => p.ProductId == productId);

            if (user != null && product != null)
            {
                // Verifique se o item já está no carrinho
                var existingCartItem = user.Carrinho.FirstOrDefault(ci => ci.ProductId == productId);

                if (existingCartItem == null)
                {
                    // O item não está no carrinho, adicione-o
                    var cartItem = new UserCartItem
                    {
                        User = user,
                        Product = product
                        // Adicione outras informações necessárias ao item do carrinho
                    };

                    user.Carrinho.Add(cartItem);
                    _bancoContext.SaveChanges();
                }
                else
                {
                    // O item já está no carrinho, você pode lidar com isso conforme necessário
                    // Por exemplo, lançar uma exceção, atualizar a quantidade, etc.
                    // Aqui, apenas deixei um comentário indicando o cenário.
                    // throw new InvalidOperationException("Item already in the cart.");
                }
            }
        }


        public void RemoverProdutoDoCarrinho(int userId, int productId)
        {
            var user = _bancoContext.Users.Include(u => u.Carrinho).FirstOrDefault(u => u.UserId == userId);

            if (user != null)
            {
                var produtoNoCarrinho = user.Carrinho.FirstOrDefault(item => item.ProductId == productId);

                if (produtoNoCarrinho != null)
                {
                    user.Carrinho.Remove(produtoNoCarrinho);
                    _bancoContext.SaveChanges();
                }
            }
        }

        public List<UserCartItem> ObterProdutosDoCarrinho(int userId)
        {
 
                    var user = _bancoContext.Users
                .Include(u => u.Carrinho)
                    .ThenInclude(ci => ci.Product)
                .FirstOrDefault(u => u.UserId == userId);

                    return user?.Carrinho.ToList();

        }

    }

}
