using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Onus
{
    [Route("api/sleep")]
    public class SleepController : Controller
    {
        private UserContext _context;

        public SleepController(UserContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public List<Sleep> Get()
        {
            return _context.sleepEntries.ToList();
        }

        [HttpGet("{id}")]
        public Sleep GetOneSleep(int id)
        {
            var s = _context.sleepEntries.FirstOrDefault(sleep => sleep.id == id);
            return s;
        }

        [HttpPost]
        public Sleep PostNewSleep ([FromBody]Sleep sleep)
        {
            _context.sleepEntries.Add(sleep);
            _context.SaveChanges();

            return sleep;
        }

        [HttpPut("{id}")]
        public Sleep PutSleepInfo(int id, [FromBody]Sleep sleep)
        {
            _context.Entry(sleep).State = EntityState.Modified;
            _context.SaveChanges();

            return sleep;
        }

        [HttpDelete("{id}")]
        public void DeleteSleep (int id)
        {
            var found = _context.sleepEntries.FirstOrDefault(i => i.id == id);
            _context.sleepEntries.Remove(found);
            _context.SaveChanges();
        }

    }
    
}