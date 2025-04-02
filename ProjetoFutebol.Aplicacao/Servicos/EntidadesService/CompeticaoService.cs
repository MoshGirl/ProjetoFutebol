using ProjetoFutebol.Dominio.DTOs;
using ProjetoFutebol.Dominio.Entidades;
using ProjetoFutebol.Dominio.Interfaces;
using ProjetoFutebol.Dominio.Interfaces.EntidadesInterface;

namespace ProjetoFutebol.Aplicacao.Servicos.EntidadesService
{
    public class CompeticaoService : ICompeticaoService
    {
        private readonly IRepository<Competicao> _repositorioCompeticao;
        private readonly IRepository<Pais> _repositorioPais;

        public CompeticaoService(IRepository<Competicao> repositorioCompeticao, IRepository<Pais> repositorioPais)
        {
            _repositorioCompeticao = repositorioCompeticao;
            _repositorioPais = repositorioPais;
        }

        public async Task AdicionarEmLoteAsync(List<Competicao> competicoes)
        {
            await _repositorioCompeticao.AdicionarEmLoteAsync(competicoes);
        }

        public async Task<List<Competicao>> ConverterCompeticoes(CompeticoesDTO competicoesDto)
        {
            if (competicoesDto == null || competicoesDto.competitions == null)
                return new List<Competicao>();

            var competicoes = new List<Competicao>();

            foreach (var competicao in competicoesDto.competitions)
            {
                if (ValidarCompeticao(competicao))
                {
                    Competicao comp = new Competicao
                    {
                        CompeticaoID = competicao.id,
                        NomeCompeticao = competicao.name,
                        Codigo = competicao.code,
                        TipoCompeticao = competicao.type,
                        Temporada = ObterTemporada(competicao.currentSeason.startDate, competicao.currentSeason.endDate)
                    };

                    var paises = await _repositorioPais.BuscarAsync(p => p.CodigoPais == competicao.area.code);
                    var pais = paises.FirstOrDefault();

                    if (pais != null)
                    {
                        comp.PaisID = pais.PaisID;
                    }

                    competicoes.Add(comp);
                }                
            }

            return competicoes;
        }

        private static bool ValidarCompeticao(CompeticoesDTO.Competition competicao) =>
            competicao?.area?.code != null &&
            !string.IsNullOrWhiteSpace(competicao.name) &&
            !string.IsNullOrWhiteSpace(competicao.code) &&
            !string.IsNullOrWhiteSpace(competicao.type) &&
            competicao.currentSeason?.startDate != null &&
            competicao.currentSeason?.endDate != null;

        private static string ObterTemporada(string startDate, string endDate) =>
            $"{DateTime.Parse(startDate).Year}/{DateTime.Parse(endDate).Year}";

        public List<Competicao> RemoverCompeticoesRepetidas(List<Competicao> competicoes)
        {
            if (competicoes == null || !competicoes.Any())
                return new List<Competicao>();

            var competicoesCadastradas = _repositorioCompeticao.ObterTodosAsync().Result.Select(x => x.Codigo);

            var competicoesFiltradas = competicoes.Where(c => !competicoesCadastradas.Contains(c.Codigo)).ToList();

            return competicoesFiltradas;
        }
    }
}
