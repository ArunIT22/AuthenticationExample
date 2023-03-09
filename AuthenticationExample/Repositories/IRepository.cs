using AuthenticationExample.Models;
using AuthenticationExample.ViewModels;

namespace AuthenticationExample.Repositories
{
    public interface IRepository
    {
        UserDetail ValidateUser(string username, string password);
    }
}
