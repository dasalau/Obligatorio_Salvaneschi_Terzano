using Obligatorio.LogicaAplicacion.Dtos.EquiposDeTrabajo;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.EquiposDeTrabajo
{
    public class GetEquiposPagosUnicosByMonto : ICUGetEquiposPagosUnicosByMonto<EquipoTrabajoDtoListado>
    {
        private readonly IRepositorioEquipoTrabajo _repo;
        public GetEquiposPagosUnicosByMonto(IRepositorioEquipoTrabajo repo)
        {
            _repo = repo;
        }

        public IEnumerable<EquipoTrabajoDtoListado> Execute(double monto)
        {

            return (EquipoDeTrabajoMapper.ToListDto(_repo.GetEquiposPagosUnicosByMonto(monto)));

        }

    }
}
