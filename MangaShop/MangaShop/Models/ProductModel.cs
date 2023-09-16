using System;
using System.ComponentModel.DataAnnotations;

namespace MangaShop.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage = "Digite o titulo do produto")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Digite a descrição do produto")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Digite o valor do produto")]
        public int Value { get; set; }
        [Required(ErrorMessage = "Selecione pelo menos uma imagem do produto")]
        public string Images { get; set; }
    }
}
