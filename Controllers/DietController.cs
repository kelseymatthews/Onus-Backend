using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Onus
{
    [Route("api/diet")]
    public class DietController : Controller
    {
        private UserContext _context;

        public DietController(UserContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public List<Diet> Get()
        {
            return _context.dietEntries.ToList();
        }


        [HttpGet("{id}")]
        public Diet GetOneDiet(int id)
        {
            var d = _context.dietEntries.FirstOrDefault(diet => diet.id == id);
            return d;
        }

        [HttpPost]
        public Diet PostNewDiet ([FromBody]Diet diet)
        {
            _context.dietEntries.Add(diet);
            _context.SaveChanges();

            return diet;
        }

        [HttpPut("{id}")]
        public Diet PutDietInfo(int id, [FromBody]Diet diet)
        {
            _context.Entry(diet).State = EntityState.Modified;
            _context.SaveChanges();

            return diet;
        }

        [HttpDelete("{id}")]
        public void DeleteDiet (int id)
        {
            var found = _context.dietEntries.FirstOrDefault(i => i.id == id);
            _context.dietEntries.Remove(found);
            _context.SaveChanges();
        }

    }
    
}