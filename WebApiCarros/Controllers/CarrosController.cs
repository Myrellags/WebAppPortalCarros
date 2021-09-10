using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCarros.Data;
using WebAppPortalCarros.Models;
using WebAppPortalCarros.Models.ViewModel;

namespace WebApiCarros.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class CarrosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: api/Carros
        [HttpGet("GetCarro")]
        public async Task<ActionResult<IEnumerable<Carro>>> GetCarro()
        {
            var listaCarros = _context.Carros.Include(e => e.Cor).Include(e => e.Combustivel).Include(e => e.Modelo);
            //return await _context.Carros.ToListAsync();
            return await listaCarros.ToListAsync();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Carro>> GetCarroId(int id)
        {
            var carro = await _context.Carros.FindAsync(id);

            if (carro == null)
            {
                return NotFound();
            }

            return carro;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarro(int id, Carro carro)
        {
            if (id != carro.CarroID)
            {
                return BadRequest();
            }

            _context.Entry(carro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarroExists(id))
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

        // POST: api/Carros
        [HttpPost("PostCarro")]
        public async Task<ActionResult<Carro>> PostCarro(Carro carro)
        {
            _context.Carros.Add(carro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarro", new { id = carro.CarroID }, carro);
        }

        // DELETE: api/Carros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarro(int id)
        {
            var carro = await _context.Carros.FindAsync(id);
            if (carro == null)
            {
                return NotFound();
            }

            _context.Carros.Remove(carro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarroExists(int id)
        {
            return _context.Carros.Any(e => e.CarroID == id);
        }
    }
}
