namespace Obligatorio.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioExiste<T>
    {
        bool Existe(T obj);
    }
}
