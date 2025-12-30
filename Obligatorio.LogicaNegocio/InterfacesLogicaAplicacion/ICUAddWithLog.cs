namespace Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion
{
    public interface ICUAddTipoGastoWithLog<T>
    {
        void Execute(T obj, int idUsuario);
    }
}
