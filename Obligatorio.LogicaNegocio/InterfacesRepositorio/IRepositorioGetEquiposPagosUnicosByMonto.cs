namespace Obligatorio.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioGetEquiposPagosUnicosByMonto<T>
    {
        IEnumerable<T> GetEquiposPagosUnicosByMonto(double monto);
    }
}
