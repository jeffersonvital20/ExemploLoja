using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExemploLojinha.Models;
using ExemploLojinha.Models.context;

namespace ExemploLojinha.Controllers
{
    public class NotasController : Controller
    {
        private readonly AppDbContext _context;

        public NotasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Notas
        //public async Task<IActionResult> Index()
        //{
        //    var appDbContext = _context.Notas.Include(n => n.Vendedor);
        //    return View(await appDbContext.ToListAsync());
        //}
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewBag.TituloParam = String.IsNullOrEmpty(sortOrder) ? "Titulo_desc" : "";
            ViewBag.ValorParam = sortOrder == "Valor" ? "Valor_desc" : "Valor";
            ViewBag.ParcelasParam = sortOrder == "Parcelas" ? "Parcelas_desc" : "Parcelas";

            var appDbContext = from n in _context.Notas select n;
            appDbContext = _context.Notas.Include(n => n.Vendedor);

            if (!String.IsNullOrEmpty(searchString))
            {
                //titulo/vendedor/data
                appDbContext = appDbContext.Where(n => n.Titulo.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "Titulo_desc":
                    appDbContext = appDbContext.OrderByDescending(n => n.Titulo);
                    break;
                case "Valor_desc":
                    appDbContext = appDbContext.OrderByDescending(n => n.ValorNota);
                    break;
                case "Parcelas_desc":
                    appDbContext = appDbContext.OrderByDescending(n => n.Parcelas);
                    break;

                default:
                    appDbContext = appDbContext.OrderBy(n => n.Titulo);
                    break;
            }

            //var appDbContext = _context.Notas.Include(n => n.Vendedor);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Notas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notas = await _context.Notas
                .Include(n => n.Vendedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notas == null)
            {
                return NotFound();
            }

            return View(notas);
        }

        // GET: Notas/Create
        public IActionResult Create()
        {
            ViewData["VendedorId"] = new SelectList(_context.Categorias, "Id", "Nome");
            ViewData["Produtos"] = new SelectList(_context.Produtos, "Id", "Nome");
            return View();
        }

        // POST: Notas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,ValorNota,Parcelas,Data,VendedorId,ProdutosId")] Notas notas)
        {
            if (ModelState.IsValid)
            {
                notas.Data = DateTime.Now;
                _context.Add(notas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VendedorId"] = new SelectList(_context.Categorias, "Id", "Nome", notas.VendedorId);
            ViewData["Produtos"] = new SelectList(_context.Produtos, "Id", "Nome", notas.ProdutosId);
            return View(notas);
        }

        // GET: Notas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notas = await _context.Notas.FindAsync(id);
            if (notas == null)
            {
                return NotFound();
            }
            ViewData["VendedorId"] = new SelectList(_context.Categorias, "Id", "Nome", notas.VendedorId);
            ViewData["Produtos"] = new SelectList(_context.Produtos, "Id", "Nome", notas.ProdutosId);
            return View(notas);
        }

        // POST: Notas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,ValorNota,Parcelas,Data,VendedorId,ProdutosId")] Notas notas)
        {
            if (id != notas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotasExists(notas.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["VendedorId"] = new SelectList(_context.Categorias, "Id", "Nome", notas.VendedorId);
            ViewData["Produtos"] = new SelectList(_context.Produtos, "Id", "Nome", notas.ProdutosId);
            return View(notas);
        }

        // GET: Notas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notas = await _context.Notas
                .Include(n => n.Vendedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notas == null)
            {
                return NotFound();
            }

            return View(notas);
        }

        // POST: Notas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notas = await _context.Notas.FindAsync(id);
            _context.Notas.Remove(notas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotasExists(int id)
        {
            return _context.Notas.Any(e => e.Id == id);
        }
    }
}
