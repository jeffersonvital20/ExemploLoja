using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploLojinha.Models
{
    [Table("Notas")]
    public class Notas
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Titulo { get; set; }
        [Required]
        public decimal ValorNota { get; set; }       
        [Required]
        public int Parcelas { get; set; }
        [Required]
        public DateTime Data { get; set; }
        //public ICollection<Vendedor> Vendedores { get; set; }
        public ICollection<Produto> Produtos { get; set; }
        public Vendedor Vendedor { get; set; }
        public int VendedorId { get; set; }
        public string ProdutosId { get; set; }

        public Notas()
        {
            //Vendedores = new Collection<Vendedor>();
            Produtos = new Collection<Produto>();
        }

       
    }
}
