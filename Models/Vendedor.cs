using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploLojinha.Models
{
    [Table("Vendedor")]
    public class Vendedor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Nome { get; set; }

        public ICollection<Notas> Notas { get; set; }
        //public Notas Nota { get; set; }
        //public int NotaId { get; set; }

        public Vendedor()
        {
            Notas = new Collection<Notas>();
        }
    }
}
