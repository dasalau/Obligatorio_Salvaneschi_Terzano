using Obligatorio.LogicaAplicacion.Dtos.Pagos;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Pagos
{
    public class GetAllPagos : ICUGetAll<PagosDtoListado>
    {
        private IRepositorioPagos _repo;

        public GetAllPagos(IRepositorioPagos repo)
        {
            _repo = repo;
        }

        public IEnumerable<PagosDtoListado> Execute()
        {
            return PagosMapper.ToListDto(_repo.GetAll());
        }
    }
}
