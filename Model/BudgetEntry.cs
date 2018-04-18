using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace Onus 
{
    public class Budget
    {
        public int id { get; set; }
        public DateTime dateEntered { get; set; }
        public int savedMoney { get; set; }
        public int spentMoney { get; set; }
        public int userId { get; set; }
        [ForeignKey( "userId" ) ]
        public virtual User user { get; set; }

    }

}