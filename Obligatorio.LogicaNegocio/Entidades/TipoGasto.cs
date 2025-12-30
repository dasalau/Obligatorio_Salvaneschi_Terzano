using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.Vo;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class TipoGasto : IEntity, IValidable
    {
        public int Id { get; set; }
        public VoDescripcion Descripcion { get; set; }

        private TipoGasto()
        {
        }

        public TipoGasto(VoDescripcion descripcion)
        {
            Descripcion = descripcion;
        }

        public void Validable()
        {

        }
    }
}
