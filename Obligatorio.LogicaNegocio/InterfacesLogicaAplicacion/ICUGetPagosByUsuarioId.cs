namespace Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion
{
    public interface ICUGetPagosByUsuarioId<T>

    {
        IEnumerable<T> Execute(int usuarioId);
    }
}
