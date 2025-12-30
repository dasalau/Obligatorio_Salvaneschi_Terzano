namespace Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion
{
    public interface ICUUpdateWithLog<T>
    {
        void Execute(int id, T Obj, int idUsuario);
    }
}
