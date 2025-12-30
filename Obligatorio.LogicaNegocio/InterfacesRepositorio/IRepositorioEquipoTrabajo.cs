using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioEquipoTrabajo :
        IRepositorioAdd<EquipoTrabajo>,
        IRepositorioGetAll<EquipoTrabajo>,
        IRepositorioGetById<EquipoTrabajo>,
        IRepositorioDelete<EquipoTrabajo>,
        IRepositorioUpdate<EquipoTrabajo>,
        IRepositorioGetEquiposPagosUnicosByMonto<EquipoTrabajo>
    {
    }
}
