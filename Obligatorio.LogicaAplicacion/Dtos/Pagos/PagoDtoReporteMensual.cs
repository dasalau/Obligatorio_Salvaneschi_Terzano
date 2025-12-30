namespace Obligatorio.LogicaAplicacion.Dtos.Pagos
{
    public record PagoDtoReporteMensual(int Id,
                                        string Descripcion,
                                        double MontoPago,
                                        int TipoGastoId,
                                        int MetodoPagoId,
                                        string DescripcionTipoPago,
                                        string MetodoPago,
                                        double Saldo)
    {
    }
}
