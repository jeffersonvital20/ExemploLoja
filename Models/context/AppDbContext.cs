using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploLojinha.Models.context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Vendedor> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Notas> Notas { get; set; }
    }
}
