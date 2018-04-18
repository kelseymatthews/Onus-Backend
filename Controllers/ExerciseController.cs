using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Onus
{
    [Route("api/exercise")]
    public class ExerciseController : Controller
    {
        private UserContext _context;

        public ExerciseController(UserContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public List<Exercise> Get()
        {
            return _context.exerciseEntries.ToList();
        }

        [HttpGet("{id}")]
        public Exercise GetOneExercise (int id)
        {
            var e = _context.exerciseEntries.FirstOrDefault(exercise => exercise.id == id);
            return e;
        }

        [HttpPost]
        public Exercise PostNewExercise ([FromBody]Exercise exercise)
        {
            _context.exerciseEntries.Add(exercise);
            _context.SaveChanges();

            return exercise;
        }

        [HttpPut("{id}")]
        public Exercise PutExerciseInfo(int id, [FromBody]Exercise exercise)
        {
            _context.Entry(exercise).State = EntityState.Modified;
            _context.SaveChanges();

            return exercise;
        }

        [HttpDelete("{id}")]
        public void DeleteExercise (int id)
        {
            var found = _context.exerciseEntries.FirstOrDefault(i => i.id == id);
            _context.exerciseEntries.Remove(found);
            _context.SaveChanges();
        }

    }
    
}