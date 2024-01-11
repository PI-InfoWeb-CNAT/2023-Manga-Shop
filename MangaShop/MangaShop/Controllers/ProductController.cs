using Microsoft.AspNetCore.Mvc;
using MangaShop.Models;
using MangaShop.Repositorio;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using MangaShop.Helper;
using MangaShop.Data;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MangaShop.Controllers
{
    public class ProductController : Controller
    {
        // Product Repositorio
        private readonly BancoContext _context;
        private readonly IProductRepositorio _productRepositorio;
        private readonly ISessao _sessao;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProductController(IProductRepositorio ProductRepositorio, ISessao sessao, BancoContext context, IWebHostEnvironment webHost)
        {
            _productRepositorio = ProductRepositorio;
            _sessao = sessao;
            _context = context;
            webHostEnvironment = webHost;
        }
        public IActionResult Index(int id)
        {
            ProductModel product = _productRepositorio.ListByid(id);
            return View("Index", product);
        }

        [HttpPost]
        public IActionResult Pesquisar(string termo)
        {
            if (string.IsNullOrEmpty(termo))
            {
                var todosOsProdutos = _context.Products.ToList();
                return View("ResultadoPesquisa", todosOsProdutos);
            }

            var resultados = _context.Products
                .Where(p => EF.Functions.Like(p.Title, $"%{termo}%"))
                .ToList();

            return View("ResultadoPesquisa", resultados);
        }

        // Criacao do produto
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductModel product)
        {
            string userSession = HttpContext.Session.GetString("LoggedUserSession");
         
            _productRepositorio.Adicionar(product, userSession);
            return View("Index", product);            

        }
        //
        public IActionResult Delete(int id)
        {
            ProductModel product = _productRepositorio.ListByid(id);
            return View(product);
        }
        public IActionResult Deletar(int id)
        {
            _productRepositorio.Deletar(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            ProductModel product = _productRepositorio.ListByid(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(ProductModel product)
        {

            _productRepositorio.Editar(product);
            return RedirectToAction("Index");
        }

    }
}
