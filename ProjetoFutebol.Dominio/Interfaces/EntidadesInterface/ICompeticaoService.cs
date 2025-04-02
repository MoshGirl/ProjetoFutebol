using ProjetoFutebol.Dominio.DTOs;
using ProjetoFutebol.Dominio.Entidades;

namespace ProjetoFutebol.Dominio.Interfaces.EntidadesInterface
{
    public interface ICompeticaoService
    {
        Task<List<Competicao>> ConverterCompeticoes(CompeticoesDTO competicoesDto);
        Task AdicionarEmLoteAsync(List<Competicao> competicoes);
        List<Competicao> RemoverCompeticoesRepetidas(List<Competicao> competicoes);
    }
}