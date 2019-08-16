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

        public virtual Categoria Categoria { get; set; }
        public int ItemId { get; set; }
        public virtual ICollection<Item> Itens { get; set; } = new List<Item>();

        public Produto()
        {

        }

        public Produto(int produtoId, string nome, Categoria categoria)
        {
            ProdutoId = produtoId;
            Nome = nome;
            Categoria = categoria;
        }

        public void AddItem(Item item)
        {
            Itens.Add(item);
        }

        public void RemoveItem(Item item)
        {
            Itens.Remove(item);
        }
    }
}