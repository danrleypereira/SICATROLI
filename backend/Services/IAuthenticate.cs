using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Services
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate(string token);
        Task<bool> RegisterUser(string token);
        Task Logout();
    }
}