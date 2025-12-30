using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Usuarios
{
    public class DeleteUsuario : ICUDelete<int>
    {
        private IRepositorioUsuario _repo;

        public DeleteUsuario(IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public void Execute(int id)
        {
            _repo.Delete(id);
        }
    }
}
