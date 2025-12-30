using Obligatorio.LogicaAplicacion.Dtos.Pagos;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Pagos
{
    public class GetPagosByTipoGastoId : ICUGetPagosByTipoGastoId<PagosByTipoGastoDtoReporte>
    {
        private IRepositorioPagos _repo;
        public GetPagosByTipoGastoId(IRepositorioPagos repo)
        {
            _repo = repo;
        }

        public IEnumerable<PagosByTipoGastoDtoReporte> Execute(int tipoGastoId)
        {

            return PagosMapper.ToListDtoReporteByTipoGasto(_repo.GetPagosByTipoGastoId(tipoGastoId));
        }
    }
}
