using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarsWebAPI.Data;
using CarsWebAPI.Models;

namespace CarsWebAPI.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyCarsController : ControllerBase
    {
        private readonly CarsCoreMvcIdentityContext _context;

        public MyCarsController(CarsCoreMvcIdentityContext context)
        {
            _context = context;
        }

        // GET: api/MyCars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyCar>>> GetMyCars()
        {
            return await _context.MyCars.ToListAsync();
        }

        // GET: api/MyCars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MyCar>> GetMyCar(int id)
        {
            var myCar = await _context.MyCars.FindAsync(id);

            if (myCar == null)
            {
                return NotFound();
            }

            return myCar;
        }

        // PUT: api/MyCars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMyCar(int id, MyCar myCar)
        {
            if (id != myCar.Id)
            {
                return BadRequest();
            }

            var carToUpdate = await _context.MyCars.FindAsync(id);

            carToUpdate.Brand = myCar.Brand;
            carToUpdate.Model = myCar.Model;
            carToUpdate.Speed = myCar.Speed;
            carToUpdate.Weight = myCar.Weight;
            carToUpdate.Price = myCar.Price;
            carToUpdate.Year = myCar.Year;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyCarExists(id))
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

        // POST: api/MyCars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MyCar>> PostMyCar(MyCar myCar)
        {
            _context.MyCars.Add(myCar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMyCar", new { id = myCar.Id }, myCar);
        }

        // DELETE: api/MyCars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMyCar(int id)
        {
            var myCar = await _context.MyCars.FindAsync(id);
            if (myCar == null)
            {
                return NotFound();
            }

            _context.MyCars.Remove(myCar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MyCarExists(int id)
        {
            return _context.MyCars.Any(e => e.Id == id);
        }

        [Route("brand/{brand}")]
        [HttpGet]
        public IQueryable<MyCar> GetcarsByBrand(string brand)
        {

            var res = from c in _context.MyCars
                      where c.Brand == brand
                      select c;

            return res;
        }

        [Route("model/{model}")]
        [HttpGet]
        public IQueryable<MyCar> GetcarsByModel(string model)
        {

            var res = from c in _context.MyCars
                      where c.Model == model
                      select c;

            return res;
        }

        [Route("year/{year}")]
        [HttpGet]
        public IQueryable<MyCar> GetcarsByYear(int year)
        {

            var res = from c in _context.MyCars
                      where c.Year.Year == year
                      select c;

            return res;
        }
    }
}
