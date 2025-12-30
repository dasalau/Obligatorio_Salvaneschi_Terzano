using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;
using Obligatorio.LogicaNegocio.Vo;


namespace Obligatorio.LogicaAplicacion.CasosUso.Usuarios
{
    // Caso de uso para cambiar la contraseña de un usuario
    public class ChangePassword : ICUChangePassword<int>
    {
        private readonly IRepositorioUsuario _repo;

        public ChangePassword(IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public void Execute(int idUsuario)
        {
            var usuario = _repo.GetById(idUsuario);
            string nuevaContrasenia = ContraseniaUtils.GenerarContrasenia(10);

            usuario.Contrasenia = new VoContrasenia(nuevaContrasenia);
            _repo.Update(idUsuario, usuario);

        }
    }
}
