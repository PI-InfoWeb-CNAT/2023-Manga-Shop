using MangaShop.Models;
using System.Collections.Generic;

namespace MangaShop.Repositorio
{
    public interface IProductRepositorio
    {
        ProductModel GetByValue(int value);
        ProductModel ListByid(int id);
        ProductModel ListByUserId(int UserId);
        List<ProductModel> ListarTodos();
        ProductModel Adicionar(ProductModel product);
        ProductModel Editar(ProductModel product);
        bool Deletar(int id);


    }
}
