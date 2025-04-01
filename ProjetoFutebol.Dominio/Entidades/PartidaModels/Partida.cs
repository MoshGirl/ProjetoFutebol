using ProjetoFutebol.Dominio.Entidades.TemporadaModels;
using ProjetoFutebol.Dominio.Entidades.Time;
using ProjetoFutebol.Dominio.Entidades.TimeModels;
using System.Text.Json.Serialization;

namespace ProjetoFutebol.Dominio.Entidades.PartidaModels
{
    public class Partida
    {
        [JsonPropertyName("area")]
        public Area Area { get; set; }

        [JsonPropertyName("competition")]
        public Competicao Competicao { get; set; }

        [JsonPropertyName("season")]
        public Temporada Temporada { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("utcDate")]
        public DateTime DataUtc { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("minute")]
        public int Minuto { get; set; }

        [JsonPropertyName("injuryTime")]
        public int TempoAdicional { get; set; }

        [JsonPropertyName("attendance")]
        public int Publico { get; set; }

        [JsonPropertyName("venue")]
        public string Estadio { get; set; }

        [JsonPropertyName("matchday")]
        public int Rodada { get; set; }

        [JsonPropertyName("stage")]
        public string Fase { get; set; }

        [JsonPropertyName("group")]
        public string Grupo { get; set; }

        [JsonPropertyName("lastUpdated")]
        public DateTime UltimaAtualizacao { get; set; }

        [JsonPropertyName("homeTeam")]
        public TimeFutebol TimeCasa { get; set; }

        [JsonPropertyName("awayTeam")]
        public TimeFutebol TimeVisitante { get; set; }

        [JsonPropertyName("score")]
        public Placar Placar { get; set; }
    }
}