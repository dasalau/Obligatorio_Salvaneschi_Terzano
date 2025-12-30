using Obligatorio.LogicaAplicacion.Dtos.TiposDeGasto;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Vo;

namespace Obligatorio.LogicaAplicacion.Mapper
{
    public static class TipoDeGastoMapper
    {
        public static TipoGasto FromDto(TiposDeGastoDtoAlta tipoGastoDto)
        {
            return new TipoGasto(
                            new VoDescripcion(tipoGastoDto.Descripcion)
                            );
        }
        public static TiposDeGastoDtoListado ToDto(TipoGasto tipoGastoDto)
        {
            return new TiposDeGastoDtoListado(
                                     tipoGastoDto.Id,
                                     tipoGastoDto.Descripcion.Value
                                     );
        }
        public static IEnumerable<TiposDeGastoDtoListado> ToListDto(IEnumerable<TipoGasto> tipoGastos)
        {
            // Retorno una lista de DTOs mapeando cada entidad a su correspondiente DTO
            return tipoGastos.Select(tg => ToDto(tg)).ToList();
        }
    }
}
