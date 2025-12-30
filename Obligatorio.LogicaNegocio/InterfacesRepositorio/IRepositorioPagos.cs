using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioPagos :
        IRepositorioAdd<Pagos>,
        IRepositorioGetAll<Pagos>,
        IRepositorioGetById<Pagos>,
        IRepositorioDelete<Pagos>,
        IRepositorioUpdate<Pagos>,
        IRepositorioExiste<Pagos>,
        IRepositorioGetPagosByUsuarioId<Pagos>,
        IRepositorioGetPagosByTipoGastoId<Pagos>
    {
    }
}
