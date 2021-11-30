using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPNet_Dukcapil_CRUD.Models;

namespace ASPNet_Dukcapil_CRUD
{
    [Route("api/[controller]")]
    [ApiController]
    public class DukcapilsAPIController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public DukcapilsAPIController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/DukcapilsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dukcapil>>> GetDukcapils()
        {
            return await _context.Dukcapils.ToListAsync();
        }

        //GET: api/DukcapilsAPI/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Dukcapil>> GetDukcapil(int id)
        {
            var dukcapil = await _context.Dukcapils.FindAsync(id);

            if (dukcapil == null)
            {
                return NotFound();
            }

            return dukcapil;
        }

        //GET: api/DukcapilsAPI/NIK/{nik}
        [HttpGet("NIK/{nik}")]
        public IActionResult FindNIK(string nik)
        {
            var dukcapil = _context.Dukcapils.Where(d => d.NIK == nik).ToList();
            DukcapilResult dukcapilresult = new DukcapilResult();

            if (dukcapil.Count == 0)
            {
                dukcapilresult.NIK = nik;
                dukcapilresult.CheckStatus = "Not Found";
                _context.DukcapilResults.Add(dukcapilresult);
                _context.SaveChanges();
                return NotFound();
            }

            var data = new 
            {
                dukcapilID = dukcapil[0].DukcapilID,
                nik = dukcapil[0].NIK,
                name = dukcapil[0].Name,
                maidenName = dukcapil[0].MaidenName,
                birthDate = dukcapil[0].BrithDate,
                gender = dukcapil[0].Gender,
                religion = _context.Religions.Where(r => r.ReligionID == dukcapil[0].ReligionID),
                marital = _context.Maritals.Where(m => m.MaritalID== dukcapil[0].MaritalID)
            };

            dukcapilresult.NIK = nik;
            dukcapilresult.CheckStatus = "Found";
            _context.DukcapilResults.Add(dukcapilresult);
            _context.SaveChanges();
            return Ok(data);
        }

        // PUT: api/DukcapilsAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDukcapil(int id, Dukcapil dukcapil)
        {
            if (id != dukcapil.DukcapilID)
            {
                return BadRequest();
            }

            _context.Entry(dukcapil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DukcapilExists(id))
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

        // POST: api/DukcapilsAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dukcapil>> PostDukcapil(Dukcapil dukcapil)
        {
            _context.Dukcapils.Add(dukcapil);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDukcapil", new { id = dukcapil.DukcapilID }, dukcapil);
        }

        // DELETE: api/DukcapilsAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDukcapil(int id)
        {
            var dukcapil = await _context.Dukcapils.FindAsync(id);
            if (dukcapil == null)
            {
                return NotFound();
            }

            _context.Dukcapils.Remove(dukcapil);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DukcapilExists(int id)
        {
            return _context.Dukcapils.Any(e => e.DukcapilID == id);
        }
    }
}
