using Obligatorio.LogicaNegocio.Vo;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Administrador : Usuario
    {
        protected Administrador()
        {
        }

        public Administrador(
            VoNombre nombre,
            VoApellido apellido,
            VoContrasenia contrasenia,
            VoEmail email,
            int equipoTrabajoId)

            : base(nombre, apellido, contrasenia, email, equipoTrabajoId)
        {
        }

    }
}
