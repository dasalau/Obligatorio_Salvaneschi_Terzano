using Obligatorio.LogicaNegocio.Excepciones;

namespace Obligatorio.LogicaNegocio.Vo
{
    public record VoNombre
    {
        public string Value { get; private set; }

        public VoNombre(string value)
        {
            Value = value;
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrEmpty(Value))
            {
                throw new NombreExcepcion("El nombre no puede estar vacio");
            }

            if (Value.Length < 2 || Value.Length > 50)
                throw new NombreExcepcion("El nombre debe tener entre 2 y 50 caracteres");
        }
    }
}
