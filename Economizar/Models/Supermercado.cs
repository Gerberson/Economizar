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

        [Display(Name = "Supermercado")]
        [Required(ErrorMessage = "O campo {0} precisa ser preenchido")]
        [DataType(DataType.Text)]
        public string Nome { get; set; }

        public Item Item { get; set; }
        public virtual ICollection<Item> Itens { get; set; }
    }

}