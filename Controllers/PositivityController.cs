using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Onus
{
    [Route("api/positivity")]
    public class PositivityController : Controller
    {
        private UserContext _context;

        public PositivityController(UserContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public List<Positivity> Get()
        {
            return _context.positivityEntries.ToList();
        }


        [HttpGet("{id}")]
        public Positivity GetOnePositivity(int id)
        {
            var p = _context.positivityEntries.FirstOrDefault(positivity => positivity.id == id);
            return p;
        }

        [HttpPost]
        public Positivity PostNewPositivity ([FromBody]Positivity positivity)
        {
            _context.positivityEntries.Add(positivity);
            _context.SaveChanges();

            return positivity;
        }

        [HttpPut("{id}")]
        public Positivity PutPositivityInfo(int id, [FromBody]Positivity positivity)
        {
            _context.Entry(positivity).State = EntityState.Modified;
            _context.SaveChanges();

            return positivity;
        }

        [HttpDelete("{id}")]
        public void DeleteUser (int id)
        {
            var found = _context.positivityEntries.FirstOrDefault(i => i.id == id);
            _context.positivityEntries.Remove(found);
            _context.SaveChanges();
        }

    }
    
}