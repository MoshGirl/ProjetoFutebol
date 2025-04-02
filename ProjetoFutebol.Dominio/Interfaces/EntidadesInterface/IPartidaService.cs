using ProjetoFutebol.Dominio.DTOs;
using ProjetoFutebol.Dominio.Entidades;

namespace ProjetoFutebol.Dominio.Interfaces.EntidadesInterface
{
    public interface IPartidaService
    {
        Task AdicionarEmLoteAsync(List<Partida> partidas);
        Task<List<Partida>> ConverterPartidas(PartidaCompeticaoDTO partidasDto, string codigoCompeticao);
    }
}