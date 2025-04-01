using ProjetoFutebol.Dominio.Entidades.JogadorModels;
using System.Text.Json.Serialization;

namespace ProjetoFutebol.Dominio.Entidades.Time
{
    public class TimeFutebol
    {
        [JsonPropertyName("id")]
        public int TimeId { get; set; }

        [JsonPropertyName("name")]
        public string? Nome { get; set; }

        [JsonPropertyName("shortName")]
        public string? NomeCurto { get; set; }

        [JsonPropertyName("tla")]
        public string? Sigla { get; set; }

        [JsonPropertyName("crest")]
        public string? Escudo { get; set; }

        [JsonPropertyName("address")]
        public string? Endereco { get; set; }

        [JsonPropertyName("website")]
        public string? Site { get; set; }

        [JsonPropertyName("founded")]
        public int Fundacao { get; set; }

        [JsonPropertyName("clubColors")]
        public string? CoresClube { get; set; }

        [JsonPropertyName("venue")]
        public string? Estadio { get; set; }

        [JsonPropertyName("lastUpdated")]
        public DateTime? UltimaAtualizacao { get; set; }

        [JsonPropertyName("coach")]
        public Tecnico? Tecnico { get; set; }

        [JsonPropertyName("leagueRank")]
        public string? RanqueLiga { get; set; }

        [JsonPropertyName("formation")]
        public string? Formacao { get; set; }

        [JsonPropertyName("lineup")]
        public IEnumerable<Jogador>? Escalacao { get; set; }

        [JsonPropertyName("bench")]
        public IEnumerable<Jogador>? Reservas { get; set; }

        [JsonPropertyName("runningCompetitions")]
        public IEnumerable<Competicao>? CompeticoesAtuais { get; set; }

        [JsonPropertyName("contract")]
        public Contrato? Contrato { get; set; }
    }
}