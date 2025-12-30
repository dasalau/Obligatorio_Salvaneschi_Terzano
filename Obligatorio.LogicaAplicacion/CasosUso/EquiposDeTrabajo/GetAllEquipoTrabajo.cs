using Obligatorio.LogicaAplicacion.Dtos.EquiposDeTrabajo;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.EquiposDeTrabajo
{
    public class GetAllEquipoTrabajo : ICUGetAll<EquipoTrabajoDtoListado>
    {
        private readonly IRepositorioEquipoTrabajo _repo;
        public GetAllEquipoTrabajo(IRepositorioEquipoTrabajo repo)
        {
            _repo = repo;
        }

        public IEnumerable<EquipoTrabajoDtoListado> Execute()
        {
            return EquipoDeTrabajoMapper.ToListDto(_repo.GetAll());
        }
    }
}
