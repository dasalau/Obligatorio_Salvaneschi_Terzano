using Obligatorio.LogicaNegocio.Excepciones;

namespace Obligatorio.LogicaNegocio.Vo
{
    public record VoDescripcion
    {
        public string Value { get; private set; }

        public VoDescripcion(string value)
        {
            Value = value;
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrEmpty(Value))
                throw new DescripcionExcepcion("La descripcion no puede estar vacia");
            if (Value.Length < 3 || Value.Length > 100)
                throw new DescripcionExcepcion("La descripcion debe tener entre 3 y 100 caracteres");
        }
    }
}
