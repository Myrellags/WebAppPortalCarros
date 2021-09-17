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

        [HttpGet("GetDonoId/{id}")]
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
        [HttpPost("DeleteDono/{id}")]
        public ActionResult DeleteDono(Dono dono)
        {
            if (!ModelState.IsValid || dono == null)
                return BadRequest("Dados do Dono inválidos");
            
            var donoSelecionado = _context.Donos.Where(c => c.DonoID == dono.DonoID).FirstOrDefault<Dono>();
            if (donoSelecionado != null)
            {
                donoSelecionado.Deletado = dono.Deletado;
                _context.Entry(donoSelecionado).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok($"Contato {dono.Deletado} excluido com sucesso!");
        }
        //[HttpDelete("DeleteDono/{id}")]
        //public IActionResult DeleteDono(int? id)
        //{
        //if (id == null)
        //    return BadRequest("Dados inválidos");
        //var donoSelecionado = _context.Donos.Where(c => c.DonoID == id).FirstOrDefault<Dono>();
        //if (donoSelecionado != null)
        //{
        //    _context.Entry(donoSelecionado).State = EntityState.Deleted;
        //    var imagemDono = _context.Imagens.Where(e => e.DonoID == donoSelecionado.DonoID).FirstOrDefault<Imagem>();
        //    var carroDono = _context.Carros.Where(e => e.DonoID == donoSelecionado.DonoID).FirstOrDefault<Carro>();
        //    var imagemCarro = _context.Imagens.Where(e => e.CarroID == carroDono.CarroID).FirstOrDefault<Imagem>();
        //    if (imagemDono != null)
        //    {
        //        _context.Entry(imagemDono).State = EntityState.Deleted;
        //    }
        //    if (carroDono != null)
        //    {
        //        _context.Entry(carroDono).State = EntityState.Deleted;
        //    }
        //    if (imagemCarro != null)
        //    {
        //        _context.Entry(imagemCarro).State = EntityState.Deleted;
        //    }
        //    _context.SaveChanges();
        //}
        //else
        //{
        //    return NotFound();
        //}
        //return Ok($"O dono {id} foi deletado com sucesso");
        //}

        private bool DonoExists(int id)
        {
            return _context.Donos.Any(e => e.DonoID == id);
        }
    }
}
