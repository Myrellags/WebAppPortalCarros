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

        [HttpGet("GetGrafico")]
        public async Task<ActionResult<IEnumerable<Carro>>> GetGrafico()
        {
            var listaCarros = _context.Carros.Include(e => e.Cor).Include(e => e.Combustivel).Include(e => e.Modelo);
            //return await _context.Carros.ToListAsync();
            return await listaCarros.ToListAsync();

        }


        [HttpGet("GetCarroId/{id}")]
        public async Task<ActionResult<Carro>> GetCarroId(int id)
        {
            var carro = await _context.Carros.FindAsync(id);

            if (carro == null)
            {
                return NotFound();
            }

            return carro;
        }

        [HttpPut("PutCarro/{id}")]
        public IActionResult PutCarro(Carro model)
        {
            if (!ModelState.IsValid || model == null)
                return BadRequest("Dados do carro inválidos");
            var carro = _context.Carros.Where(c => c.CarroID == model.CarroID).FirstOrDefault<Carro>();
            if (carro != null)
            {
                _context.Entry(carro).State = EntityState.Modified;
                var corSelecionada = _context.Cores.Where(e => e.CorID == carro.Cor.CorID).FirstOrDefault<Cor>();
                var donoSelecionado = _context.Donos.Where(e => e.DonoID == carro.Dono.DonoID).FirstOrDefault<Dono>();
                var anoSelecionado = _context.Anos.Where(e => e.CarroID == carro.CarroID).FirstOrDefault<Ano>();
                var combustivelSelecionado = _context.Combustiveis.Where(e => e.CombustivelID == carro.Combustivel.CombustivelID).FirstOrDefault<Combustivel>();
                var modeloSelecionad = _context.Modelos.Where(e => e.ModeloID == carro.Modelo.ModeloID).FirstOrDefault<Modelo>();
                var marcaSelecionada = _context.Marcas.Where(e => e.NomeMarca == carro.Modelo.Marca.NomeMarca).FirstOrDefault<Marca>();
                _context.Entry(corSelecionada).State = EntityState.Modified;
                _context.Entry(donoSelecionado).State = EntityState.Modified;
                //_context.Entry(anoSelecionado).State = EntityState.Modified;
                _context.Entry(combustivelSelecionado).State = EntityState.Modified;
                _context.Entry(modeloSelecionad).State = EntityState.Modified;
                _context.Entry(marcaSelecionada).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok($"Contato {carro.Matricula} atualizado com sucesso");





            //if (id != carro.CarroID)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(carro).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!CarroExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
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
        [HttpDelete("DeleteCarro/{id}")]
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


        //public IActionResult Delete(int? id)
        //{
        //    if (id == null)
        //        return BadRequest("Dados inválidos");

        //    var carroSelecionado = _context.Carros.Where(c => c.CarroID == id).FirstOrDefault<Carro>();
        //    if (carroSelecionado != null)
        //    {
        //        _context.Entry(carroSelecionado).State = EntityState.Deleted;
        //        var enderecoSelecionado = ctx.Enderecos.Where(e =>
        //                                     e.EnderecoId == contatoSelecionado.EnderecoId)
        //                                     .FirstOrDefault<Endereco>();
        //        if (enderecoSelecionado != null)
        //        {
        //            _context.Entry(enderecoSelecionado).State = EntityState.Deleted;
        //        }
        //        _context.SaveChanges();
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //    return Ok($"Contato {id} foi deletado com sucesso");
        //}

        private bool CarroExists(int id)
        {
            return _context.Carros.Any(e => e.CarroID == id);
        }
    }
}
