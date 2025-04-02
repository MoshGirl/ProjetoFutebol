using ProjetoFutebol.Dominio.DTOs;
using ProjetoFutebol.Dominio.Entidades;

namespace ProjetoFutebol.Dominio.Interfaces
{
    public interface IPaisService
    {
        List<Pais> ConverterAreasParaPaises(AreasDTO areasDto);
    }
}
