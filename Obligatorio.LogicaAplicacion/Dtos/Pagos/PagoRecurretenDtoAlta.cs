namespace Obligatorio.LogicaAplicacion.Dtos.Pagos
{
    public record PagoRecurrenteDtoAlta(//int id,
                               string Descripcion,
                               double MontoPago,
                               int TipoGastoId,
                               int MetodoPagoId,
                               int UsuarioId,
                               DateTime FechaDesde,
                               DateTime FechaHasta)
    {

    }
}
