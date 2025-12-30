using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.Vo;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class EquipoTrabajo : IEntity, IValidable
    {
        public int Id { get; set; }
        public VoNombre Nombre { get; set; }

        private EquipoTrabajo()
        {
        }

        public EquipoTrabajo(VoNombre nombre)
        {
            Nombre = nombre;
        }

        public void Validable()
        {

        }
    }
}
