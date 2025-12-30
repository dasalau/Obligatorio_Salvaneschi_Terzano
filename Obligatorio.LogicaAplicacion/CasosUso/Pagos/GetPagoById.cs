using Obligatorio.LogicaAplicacion.Dtos.Pagos;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Pagos
{
    public class GetPagoById : ICUGetById<PagosDtoListado>
    {
        private IRepositorioPagos _repo;

        public GetPagoById(IRepositorioPagos repo)
        {
            _repo = repo;
        }


        public PagosDtoListado Execute(int id)
        {

            return PagosMapper.ToDto(_repo.GetById(id));
        }
    }

}
