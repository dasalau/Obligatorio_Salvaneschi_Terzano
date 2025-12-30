using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Usuarios
{
    public class GetUsuarioByEmail  //No es usado por Presentacion -> no necesita interfaz
                                    //Solo chequea si existe el mail
    {
        private IRepositorioUsuario _repo;
        public GetUsuarioByEmail(IRepositorioUsuario repo)
        {
            _repo = repo;
        }
        public Usuario? Execute(string email)
        {

            var usuario = _repo.GetByEmail(email);
            return usuario;
        }
    }
}
