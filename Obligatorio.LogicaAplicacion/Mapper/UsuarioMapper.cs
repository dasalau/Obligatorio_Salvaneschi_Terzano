using Obligatorio.LogicaAplicacion.Dtos.Usuarios;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Vo;

namespace Obligatorio.LogicaAplicacion.Mapper
{
    public static class UsuarioMapper
    {
        public static Administrador FromDtoAdmininistrador(UsuarioDtoAlta usuarioDto)
        {
            return new Administrador(
                               new VoNombre(usuarioDto.Nombre),
                               new VoApellido(usuarioDto.Apellido),
                               new VoContrasenia(usuarioDto.Contrasenia),
                               new VoEmail(usuarioDto.Email),
                               usuarioDto.EquipoTrabajoId
                               );
        }

        public static Gerente FromDtoGerente(UsuarioDtoAlta usuarioDto)
        {
            return new Gerente(
                               new VoNombre(usuarioDto.Nombre),
                               new VoApellido(usuarioDto.Apellido),
                               new VoContrasenia(usuarioDto.Contrasenia),
                               new VoEmail(usuarioDto.Email),
                               usuarioDto.EquipoTrabajoId
                               );
        }

        public static Empleado FromDtoEmpleado(UsuarioDtoAlta usuarioDto)
        {
            return new Empleado(
                               new VoNombre(usuarioDto.Nombre),
                               new VoApellido(usuarioDto.Apellido),
                               new VoContrasenia(usuarioDto.Contrasenia),
                               new VoEmail(usuarioDto.Email),
                               usuarioDto.EquipoTrabajoId
                               );
        }

        public static UsuarioDtoListado ToDto(Usuario usuario)
        {
            return new UsuarioDtoListado(
                                         usuario.Id,
                                         usuario.Nombre.Value,
                                         usuario.Apellido.Value,
                                         usuario.Contrasenia.Value,  //Va?
                                         usuario.Email.Value,
                                         usuario.Rol,
                                         usuario.EquipoTrabajoId,
                                         usuario.EquipoTrabajo.Nombre.Value
                                         );
        }
        public static IEnumerable<UsuarioDtoListado> ToListDto(IEnumerable<Usuario> usuarios)
        {
            List<UsuarioDtoListado> dtos = new List<UsuarioDtoListado>();
            foreach (Usuario u in usuarios)
            {
                dtos.Add(ToDto(u));
            }
            return dtos;
        }
        public static UsuarioDtoLogeado ToDtoLogeado(Usuario usuario)
        {
            return new UsuarioDtoLogeado(usuario.Nombre.Value,
                                         usuario.Rol,
                                         usuario.Id);
        }

    }
}
