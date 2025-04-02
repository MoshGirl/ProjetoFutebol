using ProjetoFutebol.Dominio.DTOs;
using ProjetoFutebol.Dominio.Entidades;
using ProjetoFutebol.Dominio.Interfaces;
using ProjetoFutebol.Dominio.Interfaces.EntidadesInterface;

namespace ProjetoFutebol.Aplicacao.Servicos.EntidadesService
{
    public class EquipeService : IEquipeService
    {
        private readonly IRepository<Competicao> _repositorioCompeticao;
        private readonly IRepository<Equipe> _repositorioEquipe;

        public EquipeService(IRepository<Competicao> repositorioCompeticao, IRepository<Equipe> repositorioEquipe)
        {
            _repositorioCompeticao = repositorioCompeticao;
            _repositorioEquipe = repositorioEquipe;
        }

        public async Task AdicionarEmLoteAsync(List<Equipe> equipes)
        {
            await _repositorioEquipe.AdicionarEmLoteAsync(equipes);
        }

        public async Task<List<Equipe>> ConverterTimes(TimesCompeticaoDTO timesDto)
        {
            if (timesDto == null || timesDto.teams == null)
                return new List<Equipe>();

            var equipes = new List<Equipe>();
            var competicaoSalva = await _repositorioCompeticao.ObterTodosAsync();

            foreach (var team in timesDto.teams)
            {
                if (ValidarTimes(team))
                {
                    Equipe equipe = new Equipe();
                    equipe.EquipeID = team.id;
                    equipe.NomeEquipe = team.name;
                    equipe.NomeAbreviado = team.shortName;
                    equipe.Escudo = team.crest;
                    equipe.Sigla = team.tla;
                    equipe.Competicoes = new List<EquipeCompeticao>();

                    var competicoes = team.runningCompetitions;

                    if (competicoes.Any() && competicaoSalva.Any())
                    {
                        foreach (var comp in competicoes)
                        {
                            var competicao = competicaoSalva.Where(x => x.Codigo.Equals(comp.code)).FirstOrDefault();

                            if(competicao != null)
                            {
                                EquipeCompeticao equipeCompeticao = new EquipeCompeticao();
                                equipeCompeticao.CompeticaoID = competicao.CompeticaoID;

                                equipe.Competicoes.Add(equipeCompeticao);
                            }                            
                        }
                    }

                    equipes.Add(equipe);
                }
            }

            return equipes;
        }

        private bool ValidarTimes(TimesCompeticaoDTO.Team team) =>
            !string.IsNullOrEmpty(team.name) && !string.IsNullOrEmpty(team.shortName) && !string.IsNullOrEmpty(team.tla)
            && !string.IsNullOrEmpty(team.crest) && team.runningCompetitions != null;
    }
}