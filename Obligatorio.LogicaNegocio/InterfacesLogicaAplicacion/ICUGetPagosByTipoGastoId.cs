namespace Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion
{
    public interface ICUGetPagosByTipoGastoId<T>
    {
        IEnumerable<T> Execute(int tipoGastoId);
    }
}
