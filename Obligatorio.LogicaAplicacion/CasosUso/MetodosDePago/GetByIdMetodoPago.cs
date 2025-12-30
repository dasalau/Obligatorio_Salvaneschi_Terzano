using Obligatorio.LogicaAplicacion.Dtos.MetodosDePago;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.MetodosDePago
{
    public class GetByIdMetodoPago : ICUGetById<MetodosDePagoDtoListado>
    {
        private IRepositorioMetodoPago _repo;

        public GetByIdMetodoPago(IRepositorioMetodoPago repo)
        {
            _repo = repo;
        }

        public MetodosDePagoDtoListado Execute(int id)
        {
            return MetodoDePagoMapper.ToDto(_repo.GetById(id));
        }
    }
}
