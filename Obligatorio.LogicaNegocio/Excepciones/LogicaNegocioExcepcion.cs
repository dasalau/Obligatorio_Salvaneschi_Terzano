namespace Obligatorio.LogicaNegocio.Excepciones
{
    public class LogicaNegocioExcepcion : Exception
    {
        public LogicaNegocioExcepcion()
        {
        }

        public LogicaNegocioExcepcion(string? message) : base(message)
        {
        }


    }
}
