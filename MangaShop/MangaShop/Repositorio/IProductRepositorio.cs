using MangaShop.Models;
using System.Collections.Generic;

namespace MangaShop.Repositorio
{
    public interface IProductRepositorio
    {
        ProductModel GetByValue(int value);
        ProductModel ListByid(int id);
        List<ProductModel> ListByUserId(int UserId);
        List<ProductModel> ListarTodos();
        List<ProductModel> GetProductsFromCart(UserModel user);
        ProductModel Adicionar(ProductModel product, string userSession);
        ProductModel Editar(ProductModel product);
        bool Deletar(int id);


    }
}
