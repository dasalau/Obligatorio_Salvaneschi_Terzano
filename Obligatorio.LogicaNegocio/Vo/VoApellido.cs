using Obligatorio.LogicaNegocio.Excepciones;

namespace Obligatorio.LogicaNegocio.Vo
{
    public record VoApellido
    {

        public string Value { get; private set; }

        public VoApellido(string value)
        {
            Value = value;
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrEmpty(Value))
                throw new ApellidoExcepcion("El apellido no puede estar vacio");

            if (Value.Length < 2 || Value.Length > 50)
                throw new ApellidoExcepcion("El apellido debe tener entre 2 y 50 caracteres");
        }
    }
}
