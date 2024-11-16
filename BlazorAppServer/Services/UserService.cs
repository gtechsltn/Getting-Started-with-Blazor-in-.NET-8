using BlazorAppServer.Contacts;
using BlazorAppServer.Data;
using BlazorAppServer.Models;
using Dapper;

namespace BlazorAppServer.Services
{
    public class UserService : IUserService
    {
        private readonly DapperContext _connectionString;

        public UserService(DapperContext connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<LoginModel> PasswordSignInAsync(string Username, string Password)
        {
            const string query = "select *from Logins where Username=@Username and Password=@Password";

            using var connection = _connectionString.CreateDbConnection();

            var result = await connection.QueryFirstAsync<LoginModel>(query, new { Username, Password });

            return result;
        }

        public async Task<bool> CreateAsync(string Username, string Password)
        {
            const string query = "insert into Logins(Username,Password) values(@Username ,@Password)";

            using var connection = _connectionString.CreateDbConnection();

            var result = await connection.ExecuteAsync(query, new { Username, Password });

            if (result > 0) return true;
            return false;
        }

    }
}
