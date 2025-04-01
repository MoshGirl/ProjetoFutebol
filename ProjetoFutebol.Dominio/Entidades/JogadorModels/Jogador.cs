using ProjetoFutebol.Dominio.Entidades.Time;
using System.Text.Json.Serialization;

namespace ProjetoFutebol.Dominio.Entidades.JogadorModels
{
    public class Jogador
    {
        [JsonPropertyName("id")]
        public int JogadorId { get; set; }

        [JsonPropertyName("name")]
        public string? Nome { get; set; }

        [JsonPropertyName("firstName")]
        public string? PrimeiroNome { get; set; }

        [JsonPropertyName("lastName")]
        public string? UltimoNome { get; set; }

        [JsonPropertyName("dateOfBirth")]
        public DateTime? DataNascimento { get; set; }

        [JsonPropertyName("nationality")]
        public string? Nacionalidade { get; set; }

        [JsonPropertyName("position")]
        public string? Posicao { get; set; }

        [JsonPropertyName("shirtNumber")]
        public int? NumeroCamisa { get; set; }

        [JsonPropertyName("lastUpdated")]
        public DateTime? UltimaAtualizacao { get; set; }

        [JsonPropertyName("currentTeam")]
        public TimeFutebol? TimeAtual { get; set; }
    }
}