using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FormularioCadastro.Models;

namespace FormularioCadastro.Controllers
{
    public class ChamadaController : Controller
    {
        private readonly Context _context;

        public ChamadaController(Context context)
        {
            _context = context;
        }

        // GET: Chamada
        public async Task<IActionResult> Index()
        {
              return _context.chamada != null ? 
                          View(await _context.chamada.ToListAsync()) :
                          Problem("Entity set 'Context.chamada'  is null.");
        }

        // GET: Chamada/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.chamada == null)
            {
                return NotFound();
            }

            var dbChamada = await _context.chamada
                .FirstOrDefaultAsync(m => m.idchamada == id);
            if (dbChamada == null)
            {
                return NotFound();
            }

            return View(dbChamada);
        }

        // GET: Chamada/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chamada/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idchamda,nome,email,datanascimento,sexo,rua,numero,cep,cidade,estado,grauurgencia,mensagem")] DbChamada dbChamada)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbChamada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dbChamada);
        }

        // GET: Chamada/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.chamada == null)
            {
                return NotFound();
            }

            var dbChamada = await _context.chamada.FindAsync(id);
            if (dbChamada == null)
            {
                return NotFound();
            }
            return View(dbChamada);
        }

        // POST: Chamada/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idchamda,nome,email,datanascimento,sexo,rua,numero,cep,cidade,estado,grauurgencia,mensagem")] DbChamada dbChamada)
        {
            if (id != dbChamada.idchamada)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbChamada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbChamadaExists(dbChamada.idchamada))
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
            return View(dbChamada);
        }

        // GET: Chamada/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.chamada == null)
            {
                return NotFound();
            }

            var dbChamada = await _context.chamada
                .FirstOrDefaultAsync(m => m.idchamada == id);
            if (dbChamada == null)
            {
                return NotFound();
            }

            return View(dbChamada);
        }

        // POST: Chamada/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.chamada == null)
            {
                return Problem("Entity set 'Context.chamada'  is null.");
            }
            var dbChamada = await _context.chamada.FindAsync(id);
            if (dbChamada != null)
            {
                _context.chamada.Remove(dbChamada);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbChamadaExists(int id)
        {
          return (_context.chamada?.Any(e => e.idchamada == id)).GetValueOrDefault();
        }
    }
}
