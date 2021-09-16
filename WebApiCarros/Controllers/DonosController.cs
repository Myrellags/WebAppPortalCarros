using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCarros.Data;
using WebAppPortalCarros.Models;

namespace WebApiCarros.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class DonosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DonosController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: api/Donos
        [HttpGet("GetDono")]
        public async Task<ActionResult<IEnumerable<Dono>>> GetDono()
        {
            return await _context.Donos.ToListAsync();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dono>> GetDonoId(int id)
        {
            var dono = await _context.Donos.FindAsync(id);

            if (dono == null)
            {
                return NotFound();
            }

            return dono;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDono(int id, Dono dono)
        {
            if (id != dono.DonoID)
            {
                return BadRequest();
            }

            _context.Entry(dono).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonoExists(id))
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

        // POST: api/Donos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostDono")]
        public async Task<ActionResult<Dono>> PostDono(Dono dono)
        {
            _context.Donos.Add(dono);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDono", new { id = dono.DonoID }, dono);
        }

        [HttpPost("PostMorada")]
        public async Task<ActionResult<Morada>> PostMorada(Morada morada)
        {
            _context.Moradas.Add(morada);
            await _context.SaveChangesAsync();

            return View("Index");
        }

        [HttpPost("PostEmail")]
        public async Task<ActionResult<Email>> PostEmail(Email email)
        {
            _context.Emails.Add(email);
            await _context.SaveChangesAsync();

            return View("Index");
        }

        [HttpPost("PostContacto")]
        public async Task<ActionResult<Contacto>> PostContacto(Contacto contacto)
        {
            _context.Contactos.Add(contacto);
            await _context.SaveChangesAsync();

            return View("Index");
        }

        // DELETE: api/Donos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDono(int id)
        {
            var dono = await _context.Donos.FindAsync(id);
            if (dono == null)
            {
                return NotFound();
            }

            _context.Donos.Remove(dono);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DonoExists(int id)
        {
            return _context.Donos.Any(e => e.DonoID == id);
        }
    }
}
