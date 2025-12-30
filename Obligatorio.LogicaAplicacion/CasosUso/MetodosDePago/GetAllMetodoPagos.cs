using Obligatorio.LogicaAplicacion.Dtos.MetodosDePago;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.MetodosDePago
{
    public class GetAllMetodoPagos : ICUGetAll<MetodosDePagoDtoListado>
    {
        private IRepositorioMetodoPago _repo;

        public GetAllMetodoPagos(IRepositorioMetodoPago repositorioMetodoPago)
        {
            _repo = repositorioMetodoPago;
        }
        public IEnumerable<MetodosDePagoDtoListado> Execute()
        {
            return MetodoDePagoMapper.ToListDto(_repo.GetAll());
        }
    }
}

