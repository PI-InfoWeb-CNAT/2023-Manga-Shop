﻿using MangaShop.Helper;
using MangaShop.Models;
using MangaShop.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MangaShop.Controllers
{
    public class UserController : Controller
    {
        // User Repositorio
        private readonly IUserRepositorio _userRepositorio;
        private readonly ISessao _sessao;
        public UserController(IUserRepositorio userRepositorio, ISessao sessao)
        {
            _userRepositorio = userRepositorio;
            _sessao = sessao;
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
        //

        // Perfil do usuario
        public IActionResult Index(UserModel user)
        {
           
            return View(user);
        }
        public IActionResult Perfil() => View();


    }
}