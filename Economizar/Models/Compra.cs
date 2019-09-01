using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Economizar.Models
{
    public class Compra
    {
        public int CompraId { get; set; }

        [Display(Name = "Produto")]
        [Required(ErrorMessage = "O campo {0} precisa ser preenchido")]
        public string Produto { get; set; }

        [DisplayFormat(DataFormatString = "{0:N0}")]
        [Required(ErrorMessage = "O campo {0} precisa ser preenchido")]
        public int Quantidade { get; set; }

        [Display(Name = "Preço")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Preco { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal SubTotal { get { return Quantidade * Preco; } }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataCompra { get; set; }

        public string Usuario { get; set; }

        public int SupermercadoId { get; set; }
        public virtual Supermercado Supermercado { get; set; }
    }
}