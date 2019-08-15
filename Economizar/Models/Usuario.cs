using Economizar.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Economizar.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "O campo {0} precisa ser preenchido")]
        [DataType(DataType.Text)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} precisa ser preenchido")]
        [DataType(DataType.Text)]
        public string Sobrenome { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Nascimento { get; set; }
        public Sexo Sexo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Cadastro { get { return DateTime.Now; } }

        [Required(ErrorMessage = "O campo {0} precisa ser preenchido")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} precisa ser preenchido")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O campo {0} precisa ser preenchido")]
        [DataType(DataType.Password)]
        [Compare("Senha")]
        [Display(Name = "Confirmar Senha")]
        public string ConfirmarSenha { get; set; }

        public Usuario()
        {

        }

        public Usuario(int usuarioId, string nome, string sobrenome, DateTime nascimento, Sexo sexo, string email, string senha, string confirmarSenha)
        {
            UsuarioId = usuarioId;
            Nome = nome;
            Sobrenome = sobrenome;
            Nascimento = nascimento;
            Sexo = sexo;
            Email = email;
            Senha = senha;
            ConfirmarSenha = confirmarSenha;
        }
    }
}