using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Economizar.Models
{
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "O campo {0} precisa ser preenchido")]
        [DataType(DataType.Text)]
        public string Nome { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Categoria Categoria { get; set; }

        public Produto()
        {

        }

        public Produto(int produtoId, string nome, Usuario usuario, Categoria categoria)
        {
            ProdutoId = produtoId;
            Nome = nome;
            Usuario = usuario;
            Categoria = categoria;
        }
    }
}