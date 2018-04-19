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
        public List <Water> waterEntries { get; set; } 
        public List <Budget> budgetEntries { get; set; } 
        public List <Diet> dietEntries { get; set; } 
        public List <Exercise> exerciseEntries { get; set; }
        public List <Meditation> meditationEntries { get; set; } 
        public List <Positivity> positivityEntries { get; set; } 
        public List <Sleep> sleepEntries { get; set; } 
        public List <Steps> stepsEntries { get; set; } 
        public List <Todo> todoEntries { get; set; } 

    }

}