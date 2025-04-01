using ProjetoFutebol.Dominio.Entidades.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjetoFutebol.Dominio.Entidades.TemporadaModels
{
    public class Tabela
    {
        [JsonPropertyName("position")]
        public int Posicao { get; set; }

        [JsonPropertyName("team")]
        public TimeFutebol Time { get; set; }

        [JsonPropertyName("playedGames")]
        public int JogosDisputados { get; set; }

        [JsonPropertyName("form")]
        public string Forma { get; set; }

        [JsonPropertyName("won")]
        public int Vitorias { get; set; }

        [JsonPropertyName("draw")]
        public int Empates { get; set; }

        [JsonPropertyName("lost")]
        public int Derrotas { get; set; }

        [JsonPropertyName("points")]
        public int Pontos { get; set; }

        [JsonPropertyName("goalsFor")]
        public int GolsPro { get; set; }

        [JsonPropertyName("goalsAgainst")]
        public int GolsContra { get; set; }

        [JsonPropertyName("goalDifference")]
        public int SaldoGols { get; set; }
    }
}