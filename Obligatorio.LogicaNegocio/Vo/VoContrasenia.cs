using Obligatorio.LogicaNegocio.Excepciones;

namespace Obligatorio.LogicaNegocio.Vo
{
    public record VoContrasenia
    {
        public string Value { get; private set; }

        public VoContrasenia(string value)
        {
            Value = value;
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrEmpty(Value))
                throw new NombreExcepcion("La contraseña no puede estar vacio");

            if (Value.Length < 5 || Value.Length > 50)
                throw new ContraseniaExcepcion("El contraseña debe tener un mínimo de 5 caracteres");
        }

    }
}
