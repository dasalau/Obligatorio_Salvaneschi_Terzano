using Obligatorio.LogicaNegocio.InterfacesDominio;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public abstract class MetodoPago : IEntity, IValidable
    {
        public int Id { get; set; }
        public string Metodo { get; set; }

        public MetodoPago() { }


        public void Validable()
        {

        }
    }
}
