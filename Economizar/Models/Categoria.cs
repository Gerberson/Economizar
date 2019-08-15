using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Economizar.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "O campo {0} precisa ser preenchido")]
        [DataType(DataType.Text)]
        public string Nome { get; set; }

        public int ProdutoId { get; set; }
        public virtual ICollection<Produto> Produtos{ get; set; }

        public Categoria()
        {

        }

        public Categoria(int categoriaId, string nome, int produtoId)
        {
            CategoriaId = categoriaId;
            Nome = nome;
            ProdutoId = produtoId;
        }
    }
}