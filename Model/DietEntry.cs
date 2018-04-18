using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace Onus 
{
    public class Diet
    {
        public int id { get; set; }
        public DateTime dateEntered { get; set; }
        public int calories { get; set; }
        public int userId { get; set; }
        [ForeignKey( "userId" ) ]
        public virtual User user { get; set; }

    }
 
}