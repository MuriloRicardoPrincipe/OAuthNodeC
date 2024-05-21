using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Modelo;

namespace oauth.Modelo
{
    public class AuthService
    {
               
        
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> AuthenticateAsync(string username, string password)
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:3000/login", new { username, password });
            if (response.IsSuccessStatusCode)
            {
                var authResponse = await response.Content.ReadFromJsonAsync<AuthResponse>();
                return authResponse?.Token;
            }

            return null;
        }

    }
}
