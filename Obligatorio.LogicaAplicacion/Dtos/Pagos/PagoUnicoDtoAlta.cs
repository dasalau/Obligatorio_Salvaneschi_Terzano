namespace Obligatorio.LogicaAplicacion.Dtos.Pagos
{
    public record PagoUnicoDtoAlta(//int id,
                               string Descripcion,
                               double MontoPago,
                               int TipoGastoId,
                               int MetodoPagoId,
                               int UsuarioId,
                               DateTime FechaPago,
                               int NumeroRecibo)
    {
    }
}
