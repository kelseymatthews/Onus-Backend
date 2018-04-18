using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Onus
{
    [Route("api/meditation")]
    public class MeditationController : Controller
    {
        private UserContext _context;

        public MeditationController(UserContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public List<Meditation> Get()
        {
            return _context.meditationEntries.ToList();
        }


        [HttpGet("{id}")]
        public Meditation GetOneMeditation(int id)
        {
            var m = _context.meditationEntries.FirstOrDefault(meditation => meditation.id == id);
            return m;
        }

        [HttpPost]
        public Meditation PostNewMeditation ([FromBody]Meditation meditation)
        {
            _context.meditationEntries.Add(meditation);
            _context.SaveChanges();

            return meditation;
        }

        [HttpPut("{id}")]
        public Meditation PutMeditationInfo(int id, [FromBody]Meditation meditation)
        {
            _context.Entry(meditation).State = EntityState.Modified;
            _context.SaveChanges();

            return meditation;
        }

        [HttpDelete("{id}")]
        public void DeleteMeditation (int id)
        {
            var found = _context.meditationEntries.FirstOrDefault(i => i.id == id);
            _context.meditationEntries.Remove(found);
            _context.SaveChanges();
        }

    }
    
}