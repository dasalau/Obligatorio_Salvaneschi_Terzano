using Obligatorio.LogicaAplicacion.Dtos.TiposDeGasto;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.TiposDeGasto
{
    public class GetByIdTipoGasto : ICUGetById<TiposDeGastoDtoListado>
    {
        private IRepositorioTipoGasto _repo;

        public GetByIdTipoGasto(IRepositorioTipoGasto repo)
        {
            _repo = repo;
        }
        public TiposDeGastoDtoListado Execute(int id)
        {
            TipoGasto tipogasto = _repo.GetById(id);
            if (tipogasto == null) return null;           //TODO Podria lanzar una excepcion si se prefiere ¿?
            return TipoDeGastoMapper.ToDto(tipogasto);

        }
    }
}
