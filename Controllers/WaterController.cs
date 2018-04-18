using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Onus
{
    [Route("api/water")]
    public class WaterController : Controller
    {
        private UserContext _context;

        public WaterController(UserContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public List<Water> Get()
        {
            return _context.waterEntries.ToList();
        }


        [HttpGet("{id}")]
        public Water GetOneWater(int id)
        {
            var w = _context.waterEntries.FirstOrDefault(water => water.id == id);
            return w;
        }

        [HttpPost]
        public Water PostNewWater ([FromBody]Water water)
        {
            _context.waterEntries.Add(water);
            _context.SaveChanges();

            return water;
        }

        [HttpPut("{id}")]
        public Water PutWaterInfo(int id, [FromBody]Water water)
        {
            _context.Entry(water).State = EntityState.Modified;
            _context.SaveChanges();

            return water;
        }

        [HttpDelete("{id}")]
        public void DeleteWater (int id)
        {
            var found = _context.waterEntries.FirstOrDefault(i => i.id == id);
            _context.waterEntries.Remove(found);
            _context.SaveChanges();
        }

    }
    
}