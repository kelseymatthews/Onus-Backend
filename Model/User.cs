using System;
using System.Collections.Generic;

namespace Onus
{
    public class User
    {
        public int Id { get; set; }
        public string name { get; set;}
        public string lastName { get; set;}
        public string email { get; set;}
        public string password { get; set;}
        public string image_url { get; set;}
        public int age { get; set;}
        public string gender { get; set;}
        public int goalCalories { get; set; }
        public int goalExerciseHours { get; set; }
        public int goalMeditationHours { get; set; }
        public int goalSleepHours { get; set; }
        public int goalCupsOfWater { get; set; }
        public int goalSteps { get; set; }
        public virtual List <Water> waterEntries { get; set; } 
        public virtual List <Budget> budgetEntries { get; set; } 
        public virtual List <Diet> dietEntries { get; set; } 
        public virtual List <Exercise> exerciseEntries { get; set; }

        internal object Include(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        public virtual List <Meditation> meditationEntries { get; set; } 
        public virtual List <Positivity> positivityEntries { get; set; } 
        public virtual List <Sleep> sleepEntries { get; set; } 
        public virtual List <Steps> stepsEntries { get; set; } 
        public virtual List <Todo> todoEntries { get; set; } 

    }

}