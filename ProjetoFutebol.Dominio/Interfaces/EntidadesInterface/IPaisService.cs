using ProjetoFutebol.Dominio.DTOs;
using ProjetoFutebol.Dominio.Entidades;

namespace ProjetoFutebol.Dominio.Interfaces.EntidadesInterface
{
    public interface IPaisService
    {
        Task AdicionarEmLoteAsync(List<Pais> paises);
        List<Pais> ConverterAreasParaPaises(AreasDTO areasDto);
        List<Pais>? RemoverPaisesRepetidos(List<Pais> paises);
    }
}
