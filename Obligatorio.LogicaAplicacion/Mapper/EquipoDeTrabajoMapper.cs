using Obligatorio.LogicaAplicacion.Dtos.EquiposDeTrabajo;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Vo;

namespace Obligatorio.LogicaAplicacion.Mapper
{
    public static class EquipoDeTrabajoMapper
    {
        public static EquipoTrabajo FromDto(EquipoTrabajoDtoAlta equipoTrabajoDto)
        {
            return new EquipoTrabajo(
                               new VoNombre(equipoTrabajoDto.Nombre));
        }

        public static EquipoTrabajoDtoListado ToDto(EquipoTrabajo equipoTrabajoDto)
        {
            return new EquipoTrabajoDtoListado(
                                     equipoTrabajoDto.Id,
                                     equipoTrabajoDto.Nombre.Value
                                     );
        }

        public static IEnumerable<EquipoTrabajoDtoListado> ToListDto(IEnumerable<EquipoTrabajo> equiposTrabajo)
        {

            return equiposTrabajo.Select(et => ToDto(et)).ToList();
        }
    }
}
