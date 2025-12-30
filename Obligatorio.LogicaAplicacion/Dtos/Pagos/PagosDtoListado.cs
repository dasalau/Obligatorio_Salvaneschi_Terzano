namespace Obligatorio.LogicaAplicacion.Dtos.Pagos
{
    public record PagosDtoListado(int Id,
                                  string Descripcion,
                                  double MontoPago,
                                  int TipoGastoId,
                                  int MetodoPagoId,
                                  string DescripcionTipoPago,
                                  string MetodoPago

                                   )
    {
    }
}
