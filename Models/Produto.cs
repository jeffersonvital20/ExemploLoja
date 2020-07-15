using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploLojinha.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Nome { get; set; }
        [Required]
        public int Quantidade { get; set; }
        [Required]
        public decimal ValorProduto { get; set; }
        public Notas Nota { get; set; }
        

        //public Produto()
        //{
        //    Notas = new Collection<Notas>();
        //}
    }
}
