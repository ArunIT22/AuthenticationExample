using AuthenticationExample.Models;

namespace AuthenticationExample.Repositories
{
    public class AccountRepository : IRepository
    {
        private readonly BikeStoresContext _dbContext;

        public AccountRepository(BikeStoresContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserDetail ValidateUser(string username, string password)
        {
            var userDetails = _dbContext.UserDetails.FirstOrDefault(x => x.UserName == username && x.Password == password);
            return userDetails;
        }
    }
}
