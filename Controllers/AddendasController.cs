using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamenCertifac.Models;

namespace ExamenCertifac.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddendasController : ControllerBase
    {
        private readonly Cer_AddendasContext _context;

        public AddendasController(Cer_AddendasContext context)
        {
            _context = context;
        }

        // GET: api/Addendas
        [HttpGet]
        [Route("GetAddendas")]
        public ActionResult<IEnumerable<Addendas>> GetAddendas()
        {
            return _context.Addendas.ToList();
        }

        // GET: api/Addendas/5
        [HttpGet]
        [Route("GetAddendas/{id}")]
        public ActionResult<Addendas> GetAddenda(int id)
        {
            var addenda = _context.Addendas.Find(id);

            if (addenda == null)
            {
                return NotFound();
            }

            return addenda;
        }

        // PUT: api/Addendas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("UptadeAddendas/{id}")]
        public IActionResult PutAddenda(Guid id, Addendas addenda)
        {
            if (id != addenda.IdAddenda)
            {
                return BadRequest();
            }

            _context.Entry(addenda).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddendaExists(id))
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
        // POST: api/Addendas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("InsertAddendas")]
        public ActionResult<Addendas> PostAddenda(List<Addendas> addendas)
        {
            _context.Addendas.AddRange(addendas);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAddendas), addendas);
        }
        // DELETE: api/Addendas/5
        [HttpDelete]
        [Route("DeleteAddendas/{id}")]
        public IActionResult DeleteAddenda(Guid id)
        {
            var addenda = _context.Addendas.Find(id);
            if (addenda == null)
            {
                return NotFound();
            }

            // Cambiar el estado a false en lugar de eliminar físicamente
            addenda.Estado = false;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Addendas/DeleteMultiple
        [HttpDelete]
        [Route("DeleteMultiple")]
        public IActionResult DeleteMultipleAddendas(List<Guid> ids)
        {
            var addendas = _context.Addendas.Where(a => ids.Contains(a.IdAddenda)).ToList();
            if (addendas == null || !addendas.Any())
            {
                return NotFound();
            }

            foreach (var addenda in addendas)
            {
                addenda.Estado = false;
            }

            _context.SaveChanges();

            return NoContent();
        }

        // GET: api/Addendas/Range/{start}/{end}
        [HttpGet]
        [Route("Range/{start}/{end}")]
        public ActionResult<IEnumerable<Addendas>> GetAddendasByRange(DateTime start, DateTime end)
        {
            var addendas = _context.Addendas.Where(a => a.FechaModificacion >= start && a.FechaModificacion <= end).ToList();

            if (addendas == null || !addendas.Any())
            {
                return NotFound();
            }

            return addendas;
        }

        // GET: api/Addendas/Unique/{id}
        [HttpGet]
        [Route("Unique/{id}")]
        public ActionResult<Addendas> GetAddendaById(Guid id)
        {
            var addenda = _context.Addendas.Find(id);

            if (addenda == null)
            {
                return NotFound();
            }

            return addenda;
        }

        // POST: api/Addendas/Multiple
        [HttpPost]
        [Route("Multiple")]
        public ActionResult<IEnumerable<Addendas>> PostMultipleAddendas(List<Addendas> addendas)
        {
            _context.Addendas.AddRange(addendas);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAddendas), addendas);
        }

        private bool AddendaExists(Guid id)
        {
            return _context.Addendas.Any(e => e.IdAddenda == id);
        }
    }
}
