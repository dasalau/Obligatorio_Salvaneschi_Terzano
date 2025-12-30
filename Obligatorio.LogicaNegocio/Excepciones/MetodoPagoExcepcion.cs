namespace Obligatorio.LogicaNegocio.Excepciones
{
    public class MetodoPagoExcepcion : LogicaNegocioExcepcion
    {
        public MetodoPagoExcepcion()
        {
        }
        public MetodoPagoExcepcion(string message = "Metodo de pago invalido") : base(message)
        {
        }

    }
}
