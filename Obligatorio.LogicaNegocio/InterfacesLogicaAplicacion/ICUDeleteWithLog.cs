namespace Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion
{
    public interface ICUDeleteWithLog<T>
    {
        void Execute(int id, int idUsuario);
    }
}
