using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Onus
{
    [Route("api/budget")]
    public class BudgetController : Controller
    {
        private UserContext _context;

        public BudgetController(UserContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public List<Budget> Get()
        {
            return _context.budgetEntries.ToList();
        }


        [HttpGet("{id}")]
        public Budget GetOneBudget(int id)
        {
            var b = _context.budgetEntries.FirstOrDefault(budget => budget.id == id);
            return b;
        }

        [HttpPost]
        public Budget PostNewBudget ([FromBody]Budget budget)
        {
            _context.budgetEntries.Add(budget);
            _context.SaveChanges();

            return budget;
        }

        [HttpPut("{id}")]
        public Budget PutBudgetInfo (int id, [FromBody]Budget budget)
        {
            _context.Entry(budget).State = EntityState.Modified;
            _context.SaveChanges();

            return budget;
        }

        [HttpDelete("{id}")]
        public void DeleteBudget (int id)
        {
            var found = _context.budgetEntries.FirstOrDefault(i => i.id == id);
            _context.budgetEntries.Remove(found);
            _context.SaveChanges();
        }

    }
}