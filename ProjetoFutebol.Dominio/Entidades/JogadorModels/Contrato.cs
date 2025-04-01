using System.Text.Json.Serialization;

namespace ProjetoFutebol.Dominio.Entidades.JogadorModels
{
    public class Contrato
    {
        public int ContratoId { get; set; }

        [JsonPropertyName("start")]
        public string? Inicio { get; set; }

        [JsonPropertyName("until")]
        public string? Fim { get; set; }
    }
}