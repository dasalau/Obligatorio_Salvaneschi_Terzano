namespace Obligatorio.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioGetPagosByTipoGastoId<T>
    {
        IEnumerable<T> GetPagosByTipoGastoId(int tipoGastoId);
    }
}
