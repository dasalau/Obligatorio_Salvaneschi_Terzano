using Obligatorio.LogicaAplicacion.Dtos.TiposDeGasto;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.TiposDeGasto
{
    public class GetAllTipoGasto : ICUGetAll<TiposDeGastoDtoListado>
    {
        private IRepositorioTipoGasto _repo;

        public GetAllTipoGasto(IRepositorioTipoGasto repo)
        {
            _repo = repo;
        }

        public IEnumerable<TiposDeGastoDtoListado> Execute()
        {
            return TipoDeGastoMapper.ToListDto(_repo.GetAll());
        }
    }
}
