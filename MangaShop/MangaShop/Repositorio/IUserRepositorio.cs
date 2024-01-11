using MangaShop.Models;
using System.Collections.Generic;

namespace MangaShop.Repositorio
{
    public interface IUserRepositorio
    {
        UserModel GetByEmail(string email);
        UserModel ListByid(int id);
        List<UserModel> ListarTodos();
        UserModel Adicionar(UserModel user);
        UserModel Editar(UserModel user);
        void AdicionarProdutoAoCarrinho(int userId, int productId);
        void RemoverProdutoDoCarrinho(int userId, int productId);
        List<UserCartItem> ObterProdutosDoCarrinho(int userId);
        bool Deletar(int id);


    }
}
