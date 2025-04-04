﻿namespace ProjetoFutebol.Dominio.Interfaces
{
    public interface ISincronizarDadosFutebolService
    {
        Task<int> SincronizarPaisesAsync();
        Task<int> SincronizarCompeticaoPorPaises();
        Task<int> SincronizarTimesPorCompeticao(string codigoCompeticao);
        Task<int> SincronizarPartidasPorCompeticoes(string codigoCompeticao);
    }
}