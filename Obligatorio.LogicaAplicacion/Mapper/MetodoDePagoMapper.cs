using Obligatorio.LogicaAplicacion.Dtos.MetodosDePago;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaAplicacion.Mapper
{
    public static class MetodoDePagoMapper
    {
        //TODO Arreglar
        //public static Credito FromDtoCredito(MetodosDePagoDtoAlta metodoPagoDtoAlta)
        //{
        //    return new Credito();
        //}

        public static MetodosDePagoDtoListado ToDto(MetodoPago metodoPagoDto)
        {
            return new MetodosDePagoDtoListado(metodoPagoDto.Id, metodoPagoDto.Metodo);


        }
        public static IEnumerable<MetodosDePagoDtoListado> ToListDto(IEnumerable<MetodoPago> metodoPago)
        {
            List<MetodosDePagoDtoListado> dtos = new List<MetodosDePagoDtoListado>();
            foreach (MetodoPago mp in metodoPago)
            {
                dtos.Add(ToDto(mp));
            }
            return dtos;
        }
    }
}
