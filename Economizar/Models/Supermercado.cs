using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Economizar.Models
{
    public class Supermercado
    {
        [Key]
        public int SupermercadoId { get; set; }

        [Required(ErrorMessage = "O campo {0} precisa ser preenchido")]
        [DataType(DataType.Text)]
        public string Nome { get; set; }

        public int ItemId { get; set; }
        public virtual ICollection<Item> Itens { get; set; } = new List<Item>();

        public Supermercado()
        {

        }

        public Supermercado(int supermercadoId, string nome)
        {
            SupermercadoId = supermercadoId;
            Nome = nome;
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