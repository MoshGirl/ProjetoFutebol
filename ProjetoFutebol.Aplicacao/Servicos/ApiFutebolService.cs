using Microsoft.Extensions.Configuration;
using ProjetoFutebol.Dominio.DTOs;
using ProjetoFutebol.Dominio.Interfaces;
using System.Text.Json;

namespace ProjetoFutebol.Aplicacao.Servicos
{
    public class ApiFutebolService : IApiFutebolService
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

        public async Task<T> ObterDadosAsync<T>(string endpoint, string? parametro = null)
        {
            try
            {
                if (!string.IsNullOrEmpty(parametro))
                {
                    endpoint = $"{endpoint}/{parametro}";
                }

                string jsonResponse = await GetDataFromApiAsync(endpoint);

                if (string.IsNullOrEmpty(jsonResponse))
                    return default;

                return JsonSerializer.Deserialize<T>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Erro ao desserializar JSON: {ex.Message}");
                return default;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Erro na requisição HTTP: {ex.Message}");
                return default;
            }
        }
    }
}