# Onus

Onus is a bullet journal web application where users can set goals for themselves and track if the goals were met daily. The backend is used to store the users and all the data pretaining to their entries

# Prerequisites 

PostgreSQL and Postman (optional) 

# User Model
````
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
        public virtual List <Meditation> meditationEntries { get; set; } 
        public virtual List <Positivity> positivityEntries { get; set; } 
        public virtual List <Sleep> sleepEntries { get; set; } 
        public virtual List <Steps> stepsEntries { get; set; } 
        public virtual List <Todo> todoEntries { get; set; } 

    }

}

````

# Full CRUD User Controller
````
    public class UsersController : Controller
    {
        private UserContext _context;

        public UsersController(UserContext context)
        {
            _context = context;
        }

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
````
        
# Built With

C# , Entity Framework , .NET Framework and PostgreSQL
