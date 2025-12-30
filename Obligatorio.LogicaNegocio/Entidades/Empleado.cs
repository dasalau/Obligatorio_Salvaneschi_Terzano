using Obligatorio.LogicaNegocio.Vo;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Empleado : Usuario
    {
        protected Empleado()
        {
        }
        public Empleado(
            VoNombre nombre,
            VoApellido apellido,
            VoContrasenia contrasenia,
            VoEmail email,
            int equipoTrabajoId
            ) : base(nombre, apellido, contrasenia, email, equipoTrabajoId)
        {
        }

    }
}
