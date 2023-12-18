using MangaShop.Helper;
using MangaShop.Models;
using MangaShop.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Security.Policy;
using MangaShop.Data;
using Microsoft.EntityFrameworkCore;

namespace MangaShop.Controllers
{
    public class UserController : Controller
    {

        // User Repositorio
        private readonly BancoContext _context;
        private readonly IUserRepositorio _userRepositorio;
        private readonly ISessao _sessao;
       
        public UserController(IUserRepositorio userRepositorio, ISessao sessao, BancoContext context)
        {
            _userRepositorio = userRepositorio; 
            _sessao = sessao;
            _context = context;
        }
        //

        // Criacao do usuario
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Signup(UserModel user)
        {
            if (ModelState.IsValid) {
                _userRepositorio.Adicionar(user);
                return RedirectToAction("Index", "Login");
            }
            
            return View(user);
        }
        //

        // Editar usuario
        public IActionResult Edit(int id)
        {
            UserModel user = _userRepositorio.ListByid(id);
            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(UserModel user)
        {
            
            _userRepositorio.Editar(user);
            _sessao.RemoveUserSession();
            _sessao.CreateUserSession(user);
            return RedirectToAction("Index");
        }
        //
        // Deletar usuario
        public IActionResult Delete(int id)
        {
            UserModel user = _userRepositorio.ListByid(id);
            return View(user);
        }
        public IActionResult Deletar(int id)
        {
            _userRepositorio.Deletar(id);
            return RedirectToAction("Index");
        }
        // Perfil do usuario
        public IActionResult Index(UserModel user)
        {
            return View();
        }
        public IActionResult Conversas(UserModel user)
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadIcon(UserModel userModel, IFormFile icon)
        {
            if (icon != null && icon.Length > 0)
            {
                // Verifique se o arquivo foi enviado
                var nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(icon.FileName);
                var caminhoDoArquivo = Path.Combine("~/imagens/", nomeArquivo);

                using (var stream = new FileStream(caminhoDoArquivo, FileMode.Create))
                {
                    icon.CopyTo(stream);
                }

       
                userModel.IconPath = nomeArquivo;
            }
            return RedirectToAction("Index");
        }

       


    }
}
