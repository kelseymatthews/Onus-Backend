using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Onus 
{
    public class Todo
    {
        public int id { get; set; }
        public DateTime dateEntered { get; set; }
        public string individualTodo { get; set; }

        public int userId { get; set; }
        [ForeignKey( "userId" ) ]
        public virtual User user { get; set; }

    }
    
}