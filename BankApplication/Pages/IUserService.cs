namespace BankApplication.Pages
{
    // IUserService interface
    public interface IUserService
    {
        UserProfile GetUserProfile(string username);
        void UpdateUserProfile(string username, string firstName, /* other properties */);
    }

    // Concrete implementation of IUserService
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext; // Example: Entity Framework DbContext ApplicationDbContext/Database

        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserProfile GetUserProfile(string username)
        {
            // Implement logic to retrieve user profile from the database
            return _dbContext.UserProfiles.FirstOrDefault(u => u.Username == username);
        }

        public void UpdateUserProfile(string username, string firstName, /* other properties */)
        {
            // Implement logic to update user profile in the database
            var user = _dbContext.UserProfiles.FirstOrDefault(u => u.Username == username);

            if (user != null)
            {
                user.FirstName = firstName;
                // Update other properties
                _dbContext.SaveChanges();
            }
        }
    }

    // a CLASS FOR SAVING USER INFO 
    public class UserProfile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        


        UserProfile()
        {
            FirstName = string.Empty; LastName = string.Empty; Email = string.Empty;
        }
    }

}
