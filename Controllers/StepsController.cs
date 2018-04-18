using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Onus
{
    [Route("api/steps")]
    public class StepsController : Controller
    {
        private UserContext _context;

        public StepsController(UserContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public List<Steps> Get()
        {
            return _context.stepsEntries.ToList();
        }

        [HttpGet("{id}")]
        public Steps GetOneSteps(int id)
        {
            var s = _context.stepsEntries.FirstOrDefault(steps => steps.id == id);
            return s;
        }

        [HttpPost]
        public Steps PostNewSteps ([FromBody]Steps steps)
        {
            _context.stepsEntries.Add(steps);
            _context.SaveChanges();

            return steps;
        }

        [HttpPut("{id}")]
        public Steps PutStepsInfo(int id, [FromBody]Steps steps)
        {
            _context.Entry(steps).State = EntityState.Modified;
            _context.SaveChanges();

            return steps;
        }

        [HttpDelete("{id}")]
        public void DeleteSteps (int id)
        {
            var found = _context.stepsEntries.FirstOrDefault(i => i.id == id);
            _context.stepsEntries.Remove(found);
            _context.SaveChanges();
        }

    }
    
}