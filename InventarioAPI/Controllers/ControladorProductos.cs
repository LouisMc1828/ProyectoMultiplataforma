using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventarioAPI.Datos;
using InventarioAPI.Datos.Modelos;

namespace InventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControladorProductos : ControllerBase
    {
        private readonly InventarioDBContext _context;

        public ControladorProductos(InventarioDBContext context)
        {
            _context = context;
        }

        // GET: api/ControladorProductos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventarioModelo>>> GetArticulos()
        {
            return await _context.Articulos.ToListAsync();
        }

        // GET: api/ControladorProductos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InventarioModelo>> GetInventarioModelo(int id)
        {
            var inventarioModelo = await _context.Articulos.FindAsync(id);

            if (inventarioModelo == null)
            {
                return NotFound();
            }

            return inventarioModelo;
        }

        // PUT: api/ControladorProductos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventarioModelo(int id, InventarioModelo inventarioModelo)
        {
            if (id != inventarioModelo.Id)
            {
                return BadRequest();
            }

            _context.Entry(inventarioModelo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventarioModeloExists(id))
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

        // POST: api/ControladorProductos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InventarioModelo>> PostInventarioModelo(InventarioModelo inventarioModelo)
        {
            _context.Articulos.Add(inventarioModelo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventarioModelo", new { id = inventarioModelo.Id }, inventarioModelo);
        }

        // DELETE: api/ControladorProductos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventarioModelo(int id)
        {
            var inventarioModelo = await _context.Articulos.FindAsync(id);
            if (inventarioModelo == null)
            {
                return NotFound();
            }

            _context.Articulos.Remove(inventarioModelo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventarioModeloExists(int id)
        {
            return _context.Articulos.Any(e => e.Id == id);
        }
    }
}
