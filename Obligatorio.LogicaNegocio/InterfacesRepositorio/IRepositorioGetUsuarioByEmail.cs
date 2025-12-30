namespace Obligatorio.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioGetUsuarioByEmail<T>
    {
        T GetByEmail(string email);
    }
}
