using ProjetoFutebol.Dominio.DTOs;
using ProjetoFutebol.Dominio.Entidades;

namespace ProjetoFutebol.Dominio.Interfaces.EntidadesInterface
{
    public interface IPaisService
    {
        List<Pais> ConverterAreasParaPaises(AreasDTO areasDto);
    }
}
