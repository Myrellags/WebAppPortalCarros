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
        public IActionResult GetDonoId(int id)
        {
            var dono = _context.Donos.Where(d => d.DonoID == id)
                .Include(d => d.Contactos).Include(d => d.Moradas).Include(d => d.Emails).FirstOrDefault();

            DonoViewModel donoViewModel = new DonoViewModel() 
            {
                Dono = dono
                //Morada = (Morada)dono.Moradas,
                //Email = (Email)dono.Contactos,
                //Contacto = (Contacto)dono.Contactos
            };
            if (dono == null)
            {
                return NotFound();
            }
            return Ok(donoViewModel);
        }

        [HttpPut("PutDono/{id}")]
        public async Task<IActionResult> PutDono(int id, DonoViewModel dono)
        {
            if (id != dono.Dono.DonoID)
            {
                return BadRequest();
            }
            var donoId = _context.Donos.Where(d => d.DonoID == id).FirstOrDefault();
            if (donoId != null)
            {
                donoId.NIF = dono.Dono.NIF;
                donoId.Nome = dono.Dono.Nome;
            }
            else
            {
                return NotFound();
            }
            try
            {
                await _context.SaveChangesAsync(); ;
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

        [HttpPut("PutContacto/{id}")]
        public async Task<IActionResult> PutContacto(int id, Contacto contacto)
        {
            if (id != contacto.ContactoID)
            {
                return BadRequest();
            }

            _context.Entry(contacto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactoExists(id))
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

        [HttpPut("PutEmail/{id}")]
        public async Task<IActionResult> PutEmail(int id, Email email)
        {
            if (id != email.EmailID)
            {
                return BadRequest();
            }

            _context.Entry(email).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailExists(id))
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

        [HttpPut("PutMorada/{id}")]
        public async Task<IActionResult> PutMorada(int id, Morada morada)
        {
            if (id != morada.MoradaID)
            {
                return BadRequest();
            }

            _context.Entry(morada).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoradaExists(id))
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
        private bool ContactoExists(int id)
        {
            return _context.Contactos.Any(e => e.ContactoID == id);
        }
        private bool EmailExists(int id)
        {
            return _context.Emails.Any(e => e.EmailID == id);
        }
        private bool MoradaExists(int id)
        {
            return _context.Moradas.Any(e => e.MoradaID == id);
        }
    }
}
