using MangaShop.Data;
using MangaShop.Models;
using Microsoft.AspNetCore.Hosting;
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
            return _bancoContext.Users.FirstOrDefault(x => x.Id == id);
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
            UserModel userDB = ListByid(user.Id);

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

    }

}
