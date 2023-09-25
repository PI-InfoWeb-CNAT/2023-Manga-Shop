using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaShop.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o titulo do produto")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Digite a descri��o do produto")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Digite o valor do produto")]
        public int Value { get; set; }
        [Required(ErrorMessage = "Selecione pelo menos uma imagem do produto")]
        public string imagesPaths { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public virtual UserModel User { get; set; }
    }
}
