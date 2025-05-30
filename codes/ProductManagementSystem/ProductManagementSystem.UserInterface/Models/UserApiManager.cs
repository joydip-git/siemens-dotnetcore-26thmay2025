using System.Text.Json;

namespace ProductManagementSystem.UserInterface.Models
{
    //public class UserApiManager(HttpClient client) : IUserApiManager
    public class UserApiManager : IUserApiManager
    {
        private readonly IConfiguration _configuration;
        private readonly string _apiUrl;
        public UserApiManager(IConfiguration configuration)
        {
            _configuration = configuration;
            _apiUrl = _configuration["APIRequestUrls:AuthAPIUrl"] ?? "http://localhost:5030/api/auth";
        }

        public async Task<bool> SendRequestToRegisterUser(UserViewModel user)
        {
            try
            {
                using var client = new HttpClient();
                var response = await client.PostAsJsonAsync<UserViewModel>($"{_apiUrl}/register", user);
                return response.IsSuccessStatusCode;

                //var response = await client.PostAsJsonAsync<UserViewModel>($"register", user);
                //return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<string?> SendRequestToAuthenticateUser(UserViewModel user)
        {
            try
            {
                using var client = new HttpClient();
                var response = await client.PostAsJsonAsync<UserViewModel>($"{_apiUrl}/login", user);
                //var response = await client.PostAsJsonAsync<UserViewModel>($"login", user);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var jsonDoc = JsonDocument.Parse(content);
                    
                    JsonElement tokenElementObject;
                    bool status = jsonDoc.RootElement.TryGetProperty("token", out tokenElementObject);

                    return status ? tokenElementObject.GetString() : "";
                }
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
