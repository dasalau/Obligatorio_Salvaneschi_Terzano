namespace Obligatorio.LogicaAplicacion.Dtos.Pagos
{
    public record PagosByTipoGastoDtoReporte(int Id,
                                        int IdUsuario,
                                        int IdTipoGasto,
                                        string TipoPago,
                                        double MontoPago,
                                        DateTime? FechaPago,
                                        DateTime? FechaDesde,
                                        DateTime? FechaHasta
                                       )
    {

    }
}
