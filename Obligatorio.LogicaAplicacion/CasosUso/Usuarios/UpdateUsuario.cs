using Obligatorio.LogicaAplicacion.Dtos.Usuarios;
using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;
using Obligatorio.LogicaNegocio.Vo;

namespace Obligatorio.LogicaAplicacion.CasosUso.Usuarios
{
    public class UpdateUsuario : ICUUpdate<UsuarioDtoAlta>
    {
        private readonly IRepositorioUsuario _repo;
        public UpdateUsuario(IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public void Execute(int id, UsuarioDtoAlta dto)
        {
            var usuario = _repo.GetById(id);

            if (usuario == null)
            {
                throw new UsuarioExcepcion("No se ha encontrado el usuario...");
            }

            usuario.Nombre = new VoNombre(dto.Nombre);
            usuario.Apellido = new VoApellido(dto.Apellido);
            usuario.Contrasenia = new VoContrasenia(dto.Contrasenia);

            _repo.Update(id, usuario);

        }
    }
}
