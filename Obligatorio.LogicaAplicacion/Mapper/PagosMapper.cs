using Obligatorio.LogicaAplicacion.Dtos.Pagos;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Vo;

namespace Obligatorio.LogicaAplicacion.Mapper
{
    public class PagosMapper
    {
        public static Recurrente FromDtoPagosRecurrente(PagoRecurrenteDtoAlta pagoRecurrenteDtoAlta)
        {
            return new Recurrente(new VoDescripcion(pagoRecurrenteDtoAlta.Descripcion),
                                  pagoRecurrenteDtoAlta.MontoPago,
                                  pagoRecurrenteDtoAlta.TipoGastoId,
                                  pagoRecurrenteDtoAlta.MetodoPagoId,
                                  pagoRecurrenteDtoAlta.UsuarioId,
                                  pagoRecurrenteDtoAlta.FechaDesde,
                                  pagoRecurrenteDtoAlta.FechaHasta);
        }
        public static Unico FromDtoPagosUnico(PagoUnicoDtoAlta pagosUnicoDtoAlta)
        {
            return new Unico(new VoDescripcion(pagosUnicoDtoAlta.Descripcion),
                             pagosUnicoDtoAlta.MontoPago,
                             pagosUnicoDtoAlta.TipoGastoId,
                             pagosUnicoDtoAlta.MetodoPagoId,
                             pagosUnicoDtoAlta.UsuarioId,
                             pagosUnicoDtoAlta.FechaPago,
                             pagosUnicoDtoAlta.NumeroRecibo);
        }
        public static PagosDtoListado ToDto(Pagos pago)
        {
            return new PagosDtoListado(
                                     pago.Id,
                                     pago.Descripcion.Value,
                                     pago.MontoPago,
                                     pago.TipoGastoId,
                                     pago.MetodoPagoId,
                                     pago.TipoGasto.Descripcion.Value,
                                     pago.MetodoPago.Metodo
                                     //string Discriminator
                                     );
        }
        public static IEnumerable<PagosDtoListado> ToListDto(IEnumerable<Pagos> pagos)
        {
            // Retorno una lista de DTOs mapeando cada entidad a su correspondiente DTO
            return pagos.Select(p => ToDto(p)).ToList();
        }

        public static PagoDtoReporteMensual ToDtoReporte(Pagos pago)
        {
            return new PagoDtoReporteMensual(
                                     pago.Id,
                                     pago.Descripcion.Value,
                                     pago.MontoPago,
                                     pago.TipoGastoId,
                                     pago.MetodoPagoId,
                                     pago.TipoGasto.Descripcion.Value,
                                     pago.MetodoPago.Metodo,
                                     pago.GetSaldo()
                                     );
        }

        public static IEnumerable<PagoDtoReporteMensual> ToListDtoReporte(IEnumerable<Pagos> pagos)
        {
            // Retorno una lista de DTOs mapeando cada entidad a su correspondiente DTO
            return pagos.Select(p => ToDtoReporte(p)).ToList();
        }

        //Para el reporte por tipo de gasto
        public static PagosByTipoGastoDtoReporte ToDtoReporteByTipoGasto(Pagos pago)
        {
            DateTime? FechaPago = null;
            DateTime? FechaDesde = null;
            DateTime? FechaHasta = null;

            if (pago is Unico)
            {
                FechaPago = ((Unico)pago).FechaPago;
            }

            else
            {
                FechaDesde = ((Recurrente)pago).FechaDesde;
                FechaHasta = ((Recurrente)pago).FechaHasta;
            }

            return new PagosByTipoGastoDtoReporte(
                                         pago.Id,
                                         pago.UsuarioId,
                                         pago.TipoGastoId,
                                         pago.Discriminator,
                                         pago.MontoPago,
                                         FechaPago,
                                         FechaDesde,
                                         FechaHasta
                                         );
        }

        public static IEnumerable<PagosByTipoGastoDtoReporte> ToListDtoReporteByTipoGasto(IEnumerable<Pagos> pagos)
        {
            return pagos.Select(p => ToDtoReporteByTipoGasto(p)).ToList();
        }

    }
}
