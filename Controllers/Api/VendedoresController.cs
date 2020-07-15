using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExemploLojinha.Models;
using ExemploLojinha.Models.context;

namespace ExemploLojinha.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedoresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VendedoresController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Vendedores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendedor>>> GetCategorias()
        {
            return await _context.Categorias.ToListAsync();
        }

        // GET: api/Vendedores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vendedor>> GetVendedor(int id)
        {
            var vendedor = await _context.Categorias.FindAsync(id);

            if (vendedor == null)
            {
                return NotFound();
            }

            return vendedor;
        }

        // PUT: api/Vendedores/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendedor(int id, Vendedor vendedor)
        {
            if (id != vendedor.Id)
            {
                return BadRequest();
            }

            _context.Entry(vendedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendedorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Vendedores
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Vendedor>> PostVendedor(Vendedor vendedor)
        {
            _context.Categorias.Add(vendedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVendedor", new { id = vendedor.Id }, vendedor);
        }

        // DELETE: api/Vendedores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vendedor>> DeleteVendedor(int id)
        {
            var vendedor = await _context.Categorias.FindAsync(id);
            if (vendedor == null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(vendedor);
            await _context.SaveChangesAsync();

            return vendedor;
        }

        private bool VendedorExists(int id)
        {
            return _context.Categorias.Any(e => e.Id == id);
        }
    }
}
