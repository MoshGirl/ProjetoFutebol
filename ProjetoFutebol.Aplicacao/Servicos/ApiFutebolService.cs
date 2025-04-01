using Microsoft.Extensions.Configuration;
using ProjetoFutebol.Dominio.DTOs;
using System.Text.Json;

namespace ProjetoFutebol.Aplicacao.Servicos
{
    public class ApiFutebolService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;
        private readonly string _authToken;

        public ApiFutebolService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiBaseUrl = configuration["ApiFutebol:BaseUrl"];
            _authToken = configuration["ApiFutebol:AuthToken"];
        }

        public async Task<string> GetDataFromApiAsync(string endpoint)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("X-Auth-Token", _authToken);

            HttpResponseMessage response = await _httpClient.GetAsync($"{_apiBaseUrl}/{endpoint}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return $"Erro: {response.StatusCode}";
        }

        public async Task<AreasDTO> ObterAreasAsync()
        {
            string jsonResponse = await GetDataFromApiAsync("areas");

            if (string.IsNullOrEmpty(jsonResponse))
                return new AreasDTO();

            var teste = JsonSerializer.Deserialize<AreasDTO>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return JsonSerializer.Deserialize<AreasDTO>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}