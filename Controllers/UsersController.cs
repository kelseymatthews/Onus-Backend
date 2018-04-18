using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Onus
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        private UserContext _context;

        public UsersController(UserContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public List<User> Get()
        {
            return _context.users.Include(u => u.waterEntries).Include(u => u.meditationEntries).Include(u => u.budgetEntries).Include(u => u.dietEntries).Include(u => u.exerciseEntries).Include(u => u.positivityEntries).Include( u => u.sleepEntries).Include(u => u.stepsEntries).Include(u => u.todoEntries).ToList();
        }

        [HttpGet("{id}")]
        public User GetOneUser(int id)
        {
            var listOfUsers = _context.users.Include(u => u.waterEntries).Include(u => u.meditationEntries).Include(u => u.budgetEntries).Include(u => u.dietEntries).Include(u => u.exerciseEntries).Include(u => u.positivityEntries).Include( u => u.sleepEntries).Include(u => u.stepsEntries).Include(u => u.todoEntries);
            
            var soloUser = listOfUsers.FirstOrDefault(user => user.Id == id);
            return soloUser;
        }

        [HttpPost]
        public User PostNewUser ([FromBody]User user)
        {
            _context.users.Add(user);
            _context.SaveChanges();

            return user;
        }

        [HttpPut("{id}")]
        public User PutUserInfo(int id, [FromBody]User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();

            return user;
        }

        [HttpDelete("{id}")]
        public void DeleteUser (int id)
        {
            var found = _context.users.FirstOrDefault(i => i.Id == id);
            _context.users.Remove(found);
            _context.SaveChanges();
        }

    }
}