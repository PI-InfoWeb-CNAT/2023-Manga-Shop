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
        [Required(ErrorMessage = "Digite a descrição do produto")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Digite o valor do produto")]
        public int Value { get; set; }
        [Required(ErrorMessage = "Escolha um estado de conservação válido")]
        public int Conservacao { get; set; }
        public string? ImagePath { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
    }
}
