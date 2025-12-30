using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioMetodoPago :
        IRepositorioAdd<MetodoPago>,
        IRepositorioGetAll<MetodoPago>,
        IRepositorioGetById<MetodoPago>,
        IRepositorioDelete<MetodoPago>,
        IRepositorioUpdate<MetodoPago>
    {
    }
}
