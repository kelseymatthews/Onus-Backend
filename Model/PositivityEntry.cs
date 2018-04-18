using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace Onus 
{
    public class Positivity
    {
        public int id { get; set; }
        public DateTime dateEntered { get; set; }
        public string positivityEntry { get; set; }
        public int userId { get; set; }
        [ForeignKey( "userId" ) ]
        public virtual User user { get; set; }

    }
    
}