using Obligatorio.LogicaAplicacion.Dtos.Usuarios;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Usuarios
{
    public class GetByIdUsuario : ICUGetById<UsuarioDtoListado>
    {
        private IRepositorioUsuario _repo;
        public GetByIdUsuario(IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public UsuarioDtoListado Execute(int id)
        {
            Usuario usuario = _repo.GetById(id);
            if (usuario == null)
            {
                throw new UsuarioExcepcion("No se encontro el usuario con id: " + id);
            }

            return UsuarioMapper.ToDto(usuario);  //Aca obtengo un DtoListado


        }
    }
}
