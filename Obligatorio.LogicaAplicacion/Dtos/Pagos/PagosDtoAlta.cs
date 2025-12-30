namespace Obligatorio.LogicaAplicacion.Dtos.Pagos
{
    //TODO - Eliminar ???
    public record PagosDtoAlta(int id,
                               string Descripcion,
                               double MontoPago,
                               DateTime FechaDesde,
                               DateTime FechaHasta)
    {
    }
}
