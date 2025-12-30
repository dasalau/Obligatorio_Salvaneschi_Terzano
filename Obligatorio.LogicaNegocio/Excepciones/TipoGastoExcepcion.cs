namespace Obligatorio.LogicaNegocio.Excepciones
{
    public class TipoGastoExcepcion : LogicaNegocioExcepcion
    {
        public TipoGastoExcepcion(string? message = "El tipo de gasto es invalido...") : base(message)
        {
        }
    }
}
