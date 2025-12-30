using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioUsuario :
        IRepositorioAdd<Usuario>,
        IRepositorioGetAll<Usuario>,
        IRepositorioGetById<Usuario>,
        IRepositorioDelete<Usuario>,
        IRepositorioUpdate<Usuario>,
        IRepositorioGetUsuarioByEmail<Usuario>
    {
    }
}
