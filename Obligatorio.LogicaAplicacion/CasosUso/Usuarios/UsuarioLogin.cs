using Obligatorio.LogicaAplicacion.Dtos.Usuarios;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Usuarios
{
    public class UsuarioLogin : ICUUsuarioLogin<UsuarioDtoLogin, UsuarioDtoLogeado>

    {
        private IRepositorioUsuario _repo;
        public UsuarioLogin(IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public UsuarioDtoLogeado Execute(UsuarioDtoLogin dtoLogin)
        {
            Usuario u = _repo.GetByEmail(dtoLogin.Email);
            if (u != null && dtoLogin.Contrasenia == u.Contrasenia.Value)
            {
                return UsuarioMapper.ToDtoLogeado(u);
            }
            throw new UsuarioExcepcion("Los datos recibidos no son correctos");
        }
    }
}

