namespace Obligatorio.LogicaNegocio.Excepciones
{
    public class PagosExcepcion : Exception
    {
        public PagosExcepcion()
        {
        }

        public PagosExcepcion(string? message) : base(message)
        {
        }
    }
}
