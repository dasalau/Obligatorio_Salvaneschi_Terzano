namespace Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion
{
    public interface ICUGetPagosMesAnio<T>
    {
        IEnumerable<T> Execute(int mes, int anio);
    }
}
