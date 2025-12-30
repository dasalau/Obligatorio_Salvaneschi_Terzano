namespace Obligatorio.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioGetPagosByUsuarioId<T>
    {
        IEnumerable<T> GetPagosByUsuarioId(int usuarioId);
    }
}
