using MangaShop.Helper;
using MangaShop.Models;
using MangaShop.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MangaShop.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepositorio _userRepositorio;
        private readonly ISessao _sessao;
        public LoginController(IUserRepositorio userRepositorio, ISessao sessao)
        {
            _userRepositorio = userRepositorio;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            // Se logado redirecionar para perfil
            if (_sessao.GetUserSession() != null) return RedirectToAction("Index", "User");
            return View();
        }

        public IActionResult Quit()
        {
            _sessao.RemoveUserSession();

            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
          
                if(ModelState.IsValid) { 

                    UserModel user = _userRepositorio.GetByEmail(loginModel.Email);
                    
                    if(user != null)
                        {         
                        if (user.ValidPassword(loginModel.Password))
                        {
                        _sessao.CreateUserSession(user);
                        return RedirectToAction("Index", "Home");
                        }
                    TempData["MensagemErro"] = "Email e/ou senha não são validos";
                    return View("Index");
                }
                TempData["MensagemErro"] = "Email e/ou senha não são validos";
                return View("Index");
                }
                return RedirectToAction("Signup", "User");
        }
    }
}
