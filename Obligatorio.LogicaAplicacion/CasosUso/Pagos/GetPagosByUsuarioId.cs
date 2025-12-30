using Obligatorio.LogicaAplicacion.Dtos.Pagos;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Pagos
{
    public class GetPagosByUsuarioId : ICUGetPagosByUsuarioId<PagosDtoListado>
    {
        private IRepositorioPagos _repo;
        public GetPagosByUsuarioId(IRepositorioPagos repo)
        {
            _repo = repo;
        }

        public IEnumerable<PagosDtoListado> Execute(int usuarioId)
        {

            return PagosMapper.ToListDto(_repo.GetPagosByUsuarioId(usuarioId));

        }
    }
}
