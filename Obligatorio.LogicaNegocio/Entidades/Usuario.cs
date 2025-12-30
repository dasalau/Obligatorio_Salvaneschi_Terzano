using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.Vo;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public abstract class Usuario : IEntity, IValidable
    {
        public int Id { get; set; }
        public VoNombre Nombre { get; set; }
        public VoApellido Apellido { get; set; }
        public VoContrasenia Contrasenia { get; set; }
        public VoEmail Email { get; set; }
        public string Rol { get; set; }
        public EquipoTrabajo EquipoTrabajo { get; set; }
        public int EquipoTrabajoId { get; set; }


        protected Usuario()
        {
        }

        public Usuario(VoNombre nombre,
                       VoApellido apellido,
                       VoContrasenia contrasenia,
                       VoEmail email,
                       int equipoTrabajoId)
        {
            Nombre = nombre;
            Apellido = apellido;
            Contrasenia = contrasenia;
            Email = email;
            EquipoTrabajoId = equipoTrabajoId;

            Validable();
        }

        public void Validable()
        {
            if (EquipoTrabajoId == 0)
                throw new UsuarioExcepcion("El equipo de trabajo es obligatorio");

        }

    }
}
