using ProjetoFutebol.Dominio.DTOs;
using ProjetoFutebol.Dominio.Entidades;

namespace ProjetoFutebol.Dominio.Interfaces.EntidadesInterface
{
    public interface IEquipeService
    {
        Task<List<Equipe>> ConverterTimes(TimesCompeticaoDTO timesDto);
        Task AdicionarEmLoteAsync(List<Equipe> equipes);
    }
}