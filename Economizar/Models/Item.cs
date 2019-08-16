using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Economizar.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N}")]
        public int Quantidade { get; set; }

        [Display(Name ="Preço")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString ="{0:C2}")]
        public double Preco { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataCompra { get { return DateTime.Now; } }

        public virtual Usuario Usuario{ get; set; }
        public virtual Produto Produto{ get; set; }
        public virtual Supermercado Supermercado { get; set; }

        public Item()
        {

        }

        public Item(int itemId, int quantidade, double preco, Usuario usuario, Produto produto, Supermercado supermercado)
        {
            ItemId = itemId;
            Quantidade = quantidade;
            Preco = preco;
            Usuario = usuario;
            Produto = produto;
            Supermercado = supermercado;
        }
    }
}