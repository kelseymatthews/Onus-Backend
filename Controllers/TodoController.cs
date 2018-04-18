using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Onus
{
    [Route("api/todo")]
    public class TodoController : Controller
    {
        private UserContext _context;

        public TodoController(UserContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public List<Todo> Get()
        {
            return _context.todoEntries.ToList();
        }

        [HttpGet("{id}")]
        public Todo GetOneTodo(int id)
        {
            var t = _context.todoEntries.FirstOrDefault(todo => todo.id == id);
            return t;
        }

        [HttpPost]
        public Todo PostNewTodo ([FromBody]Todo todo)
        {
            _context.todoEntries.Add(todo);
            _context.SaveChanges();

            return todo;
        }

        [HttpPut("{id}")]
        public Todo PutTodoInfo(int id, [FromBody]Todo todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            _context.SaveChanges();

            return todo;
        }

        [HttpDelete("{id}")]
        public void DeleteTodo (int id)
        {
            var found = _context.todoEntries.FirstOrDefault(i => i.id == id);
            _context.todoEntries.Remove(found);
            _context.SaveChanges();
        }

    }
}