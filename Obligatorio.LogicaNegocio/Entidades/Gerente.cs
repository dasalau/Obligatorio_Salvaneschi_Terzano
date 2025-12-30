using Obligatorio.LogicaNegocio.Vo;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Gerente : Usuario
    {
        protected Gerente()
        {
        }
        public Gerente(
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
