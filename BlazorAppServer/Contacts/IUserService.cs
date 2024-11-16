using BlazorAppServer.Models;

namespace BlazorAppServer.Contacts
{
    public interface IUserService
    {
        Task<LoginModel> PasswordSignInAsync(string Username, string Password);
        Task<bool> CreateAsync(string Username, string Password);
    }
}