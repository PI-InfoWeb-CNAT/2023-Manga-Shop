﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaShop.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o seu nome")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Digite o seu e-mail")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido")]
        public string Email { get; set; }
        public long Cpf { get; set; }
        [Required(ErrorMessage = "Digite a sua senha")]
        public string Password { get; set; }
        public string? IconPath { get; set; }
        [NotMapped]
        public IFormFile Icon { get; set; }

        public string? PhoneNumber { get; set; }
        public string? Campus { get; set; }
        public string? Curso { get; set; }
        public bool ValidPassword(string password)
        {
            return Password == password;
        }
    }
}
