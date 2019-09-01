using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Economizar.Models;
using Microsoft.AspNet.Identity;

namespace Economizar.Models
{
    public class Item
    {        
        public int ItemId { get; set; }

        [Display(Name = "Produto")]
        [Required(ErrorMessage = "O campo {0} precisa ser preenchido")]
        public string Produto { get; set; }

        [DisplayFormat(DataFormatString = "{0:N0}")]
        [Required(ErrorMessage = "O campo {0} precisa ser preenchido")]
        public int Quantidade  { get; set; }

        [Display(Name ="Preço")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Preco { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal SubTotal { get { return Quantidade * Preco; }}

        [Display(Name = "Maximo")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal ValorMax { get; set; }

        [Display(Name = "Minimo")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal ValorMin { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataCompra { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Usuario { get; set; }

        [Range(1,500,ErrorMessage = "O campo supermercado precisa ser preenchido")]
        public int SupermercadoId { get; set; }
        public virtual Supermercado Supermercado { get; set; }
    }    
}