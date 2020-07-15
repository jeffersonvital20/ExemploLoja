﻿using System;
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
    public class NotasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NotasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Notas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notas>>> GetNotas()
        {
            return await _context.Notas.ToListAsync();
        }

        // GET: api/Notas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Notas>> GetNotas(int id)
        {
            var notas = await _context.Notas.FindAsync(id);

            if (notas == null)
            {
                return NotFound();
            }

            return notas;
        }
        //[HttpGet("{sortOrder}/{searchString}")]
        //public async Task<ActionResult<Notas>> GetNotas(string sortOrder, string searchString)
        //{
        //    return NotFound();
        //}

            // PUT: api/Notas/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPut("{id}")]
        public async Task<IActionResult> PutNotas(int id, Notas notas)
        {
            if (id != notas.Id)
            {
                return BadRequest();
            }

            _context.Entry(notas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotasExists(id))
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

        // POST: api/Notas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Notas>> PostNotas(Notas notas)
        {
            _context.Notas.Add(notas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotas", new { id = notas.Id }, notas);
        }

        // DELETE: api/Notas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Notas>> DeleteNotas(int id)
        {
            var notas = await _context.Notas.FindAsync(id);
            if (notas == null)
            {
                return NotFound();
            }

            _context.Notas.Remove(notas);
            await _context.SaveChangesAsync();

            return notas;
        }

        private bool NotasExists(int id)
        {
            return _context.Notas.Any(e => e.Id == id);
        }
    }
}
