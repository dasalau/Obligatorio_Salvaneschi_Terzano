using Obligatorio.LogicaAplicacion.Dtos.Usuarios;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Usuarios
{
    public class GetAllUsuario : ICUGetAll<UsuarioDtoListado>
    {
        private IRepositorioUsuario _repo;
        public GetAllUsuario(IRepositorioUsuario repo)
        {
            _repo = repo;
        }
        public IEnumerable<UsuarioDtoListado> Execute()
        {
            return UsuarioMapper.ToListDto(_repo.GetAll());
        }
    }
}
