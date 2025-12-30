using Obligatorio.LogicaAplicacion.Dtos.Usuarios;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Usuarios
{
    public class UsuarioMontoSuperior : ICUUsuarioMontoSuperior<UsuarioDtoListado>
    {
        private IRepositorioPagos _repoPagos;
        private IRepositorioUsuario _repoUsuario;

        public UsuarioMontoSuperior(IRepositorioPagos repoPagos, IRepositorioUsuario repoUsuairo)
        {
            _repoPagos = repoPagos;
            _repoUsuario = repoUsuairo;
        }

        public IEnumerable<UsuarioDtoListado> Execute(double MontoPago)
        {
            if (MontoPago <= 0)
                throw new ArgumentException("El monto debe ser mayor a cero.");

            var pagos = _repoPagos.GetAll();
            var pagosFiltrados = pagos.Where(p => p.MontoPago > MontoPago && p.Discriminator == "Unico").ToList();
            var usuarios = pagosFiltrados.Select(p => _repoUsuario.GetById(p.UsuarioId))
                                                .Distinct().ToList();

            return UsuarioMapper.ToListDto(usuarios);
        }

    }
}
