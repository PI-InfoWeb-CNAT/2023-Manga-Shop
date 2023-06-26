using System.Linq;

namespace WebAppComercioEletronico.Models
{
    public class Home
    {
        public IQueryable<Usuario> Usuarios;
        //public IQueryable<Produto> produtos;
        public string filtro;


    }
}