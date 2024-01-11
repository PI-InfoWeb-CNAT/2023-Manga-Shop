using System.Linq;
using MangaShop.Models;
using MangaShop.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using Serilog;

public class CarrinhoController : Controller
{
    private readonly IProductRepositorio _productRepositorio;
    private readonly IUserRepositorio _userRepositorio;

    public CarrinhoController(IProductRepositorio productRepositorio, IUserRepositorio userRepositorio)
    {
        _productRepositorio = productRepositorio;
        _userRepositorio = userRepositorio;
    }

    public IActionResult Index()
    {

            string userSession = HttpContext.Session.GetString("LoggedUserSession");
            UserModel user = JsonConvert.DeserializeObject<UserModel>(userSession);
            if (user != null)
            {
                var carrinhoItens = _userRepositorio.ObterProdutosDoCarrinho(user.UserId);
                return View(carrinhoItens);
            }

            // Lógica adicional se o usuário não estiver logado
            return RedirectToAction("Login", "Conta"); // Exemplo de redirecionamento para uma página de login
      

    }

    [HttpPost]
    public IActionResult AdicionarAoCarrinho(int productId)
    {
        // Lógica para adicionar um produto ao carrinho
        string userSession = HttpContext.Session.GetString("LoggedUserSession");
        UserModel user = JsonConvert.DeserializeObject<UserModel>(userSession);
        if (user != null)
        {
            // Adicionar lógica para adicionar o produto ao carrinho
            _userRepositorio.AdicionarProdutoAoCarrinho(user.UserId, productId);
        }

        return RedirectToAction("Index");
    }
    [HttpPost]
    public IActionResult RemoverDoCarrinho(int productId)
    {
        // Lógica para remover um produto do carrinho
        string userSession = HttpContext.Session.GetString("LoggedUserSession");
        UserModel user = JsonConvert.DeserializeObject<UserModel>(userSession);
        if (user != null)
        {
            // Adicionar lógica para remover o produto do carrinho
            _userRepositorio.RemoverProdutoDoCarrinho(user.UserId, productId);
        }

        return RedirectToAction("Index");
    }

    private UserModel ObterUsuarioLogado()
    {
        if (HttpContext.Session.TryGetValue("LoggedUserSession", out byte[] userSessionBytes))
        {
            string userSession = System.Text.Encoding.UTF8.GetString(userSessionBytes);
            return JsonConvert.DeserializeObject<UserModel>(userSession);
        }

        return null;
    }
}
