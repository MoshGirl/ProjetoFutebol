using ProjetoFutebol.Dominio.DTOs;
using ProjetoFutebol.Dominio.Entidades;
using ProjetoFutebol.Dominio.Interfaces;
using ProjetoFutebol.Dominio.Interfaces.EntidadesInterface;

namespace ProjetoFutebol.Aplicacao.Servicos.EntidadesService
{
    public class PartidaService : IPartidaService
    {
        private readonly IRepository<Partida> _repositorioPartida;
        private readonly IRepository<Placar> _repositorioPlacar;
        private readonly IRepository<Competicao> _repositorioCompeticao;
        private readonly IRepository<Equipe> _repositorioEquipe;

        public PartidaService(IRepository<Partida> repositorioPartida, IRepository<Placar> repositorioPlacar, IRepository<Equipe> repositorioEquipe, IRepository<Competicao> repositorioCompeticao)
        {
            _repositorioPartida = repositorioPartida;
            _repositorioPlacar = repositorioPlacar;
            _repositorioEquipe = repositorioEquipe;
            _repositorioCompeticao = repositorioCompeticao;
        }

        public async Task AdicionarEmLoteAsync(List<Partida> partidas)
        {
            await _repositorioPartida.AdicionarEmLoteAsync(partidas);
        }

        public async Task<List<Partida>> ConverterPartidas(PartidaCompeticaoDTO partidasDto, string codigoCompeticao)
        {
            if (partidasDto == null || partidasDto.matches == null)
                return new List<Partida>();

            var partidas = new List<Partida>();
            var competicaoSalva = await _repositorioCompeticao.ObterTodosAsync();
            var equipes = await _repositorioEquipe.ObterTodosAsync();

            var competicao = competicaoSalva.Where(x => x.Codigo.Equals(codigoCompeticao)).FirstOrDefault();

            if(competicao != null && equipes != null)
            {
                foreach (var partidaDTO in partidasDto.matches)
                {
                    var equipeCasa = equipes.Where(x => x.Sigla.Equals(partidaDTO.homeTeam.tla)).FirstOrDefault();
                    var equipeVisitante = equipes.Where(x => x.Sigla.Equals(partidaDTO.awayTeam.tla)).FirstOrDefault();

                    if (ValidarPartida(partidaDTO, equipeCasa, equipeVisitante))
                    {
                        Partida partida = new Partida();
                        partida.DataPartida = partidaDTO.utcDate;
                        partida.CompeticaoID = competicao.CompeticaoID;
                        partida.TimeDaCasaID = equipeCasa.EquipeID;
                        partida.TimeVisitanteID = equipeVisitante.EquipeID;

                        if (!string.IsNullOrEmpty(partidaDTO.score.winner))
                        {
                            partida.Placar = new Placar();
                            partida.Placar.PlacarVisitante = (int)partidaDTO.score.fullTime.away;
                            partida.Placar.PlacarTimeDaCasa = (int)partidaDTO.score.fullTime.home;

                            if (partidaDTO.score.winner.Equals("AWAY_TEAM"))
                                partida.Placar.VencedorID = equipeVisitante.EquipeID;
                            else if (partidaDTO.score.winner.Equals("DRAW"))
                                partida.Placar.VencedorID = null;
                            else
                                partida.Placar.VencedorID = equipeCasa.EquipeID;
                        }

                        partidas.Add(partida);
                    }
                }
            }
            else
            {
                throw new Exception("Competição não encontrada");
            }

            return partidas;
        }

        private static bool ValidarPartida(PartidaCompeticaoDTO.Match partidaDTO, Equipe? equipeCasa, Equipe? equipeVisitante) =>
            partidaDTO.utcDate != null || equipeCasa != null || equipeVisitante != null;
    }
}
