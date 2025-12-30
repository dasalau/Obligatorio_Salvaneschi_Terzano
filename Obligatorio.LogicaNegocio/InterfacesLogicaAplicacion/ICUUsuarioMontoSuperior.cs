namespace Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion
{
    public interface ICUUsuarioMontoSuperior<T>
    {
        IEnumerable<T> Execute(double monto);
    }
}
