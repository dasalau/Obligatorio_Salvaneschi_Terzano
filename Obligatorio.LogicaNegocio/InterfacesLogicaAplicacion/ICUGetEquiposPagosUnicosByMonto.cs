namespace Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion
{
    public interface ICUGetEquiposPagosUnicosByMonto<T>
    {
        IEnumerable<T> Execute(double monto);
    }
}
