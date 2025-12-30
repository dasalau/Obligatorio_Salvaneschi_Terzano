using Obligatorio.LogicaNegocio.Excepciones;

namespace Obligatorio.LogicaNegocio.Vo
{
    public record VoEmail
    {

        public string Value { get; private set; }

        public VoEmail(string value)
        {
            Value = value;
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrEmpty(Value))
                throw new NombreExcepcion("El email no puede estar vacio");
        }
    }
}
