using MangaShop.Data;
using MangaShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace MangaShop.Repositorio
{
    public class UserRepositorio : IUserRepositorio
    {
        private readonly BancoContext _bancoContext;
        public UserRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
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
            
            userDB.Name = user.Name;
            // userDB.Email = user.Email;
            userDB.Cpf = user.Cpf;
            // userDB.Password = user.Password;
            userDB.Campus = user.Campus;
            userDB.Curso = user.Curso;
            userDB.PhoneNumber = user.PhoneNumber;
            
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
    }
}
