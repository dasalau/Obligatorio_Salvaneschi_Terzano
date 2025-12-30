namespace Obligatorio.LogicaNegocio.Excepciones
{
    public class UsuarioExcepcion : Exception
    {
        public UsuarioExcepcion(string? message = "Dato invalido...") : base(message)
        {
        }
    }
}
