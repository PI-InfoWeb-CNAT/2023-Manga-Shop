using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MangaShop.Models
{
    public class UserCartItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartItemId { get; set; }

        // Relacionamento com usuário
        public int UserId { get; set; }
        public UserModel User { get; set; }

        // Relacionamento com produto
        public int ProductId { get; set; }
        public ProductModel Product { get; set; }

    }
}