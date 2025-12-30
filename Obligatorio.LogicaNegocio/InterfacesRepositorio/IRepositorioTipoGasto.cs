using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioTipoGasto :
        IRepositorioAdd<TipoGasto>,
        IRepositorioGetAll<TipoGasto>,
        IRepositorioGetById<TipoGasto>,
         IRepositorioDelete<TipoGasto>,
        IRepositorioUpdate<TipoGasto>
    {
    }
}
