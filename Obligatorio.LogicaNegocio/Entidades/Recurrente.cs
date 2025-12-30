using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.Vo;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Recurrente : Pagos
    {
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }

        public override double GetSaldo()
        {
            int numMeses;
            if (FechaHasta < DateTime.Now)
            {
                numMeses = 0;
            }

            else if (DateTime.Now < FechaDesde)
            {
                numMeses = (FechaHasta.Month - FechaDesde.Month + (FechaHasta.Year - FechaDesde.Year) * 12);
            }
            else
            {
                numMeses = (FechaHasta.Year - DateTime.Now.Year) * 12 + FechaHasta.Month - DateTime.Now.Month;
            }

            return Math.Round(numMeses * MontoPago, 2);
        }

        protected Recurrente()
        {
        }

        public Recurrente(VoDescripcion descripcion,
                          double montoPago,
                          int tipoGastoId,
                          int metodoPagoId,
                          int usuarioId,
                          DateTime fechaDesde,
                          DateTime fechaHasta) : base(descripcion,
                                                      montoPago,
                                                      tipoGastoId,
                                                      metodoPagoId,
                                                      usuarioId)
        {
            FechaDesde = fechaDesde;
            FechaHasta = fechaHasta;
        }

        public override void Validable()
        {
            base.Validable();
            if (FechaDesde > FechaHasta)
                throw new PagosExcepcion("La fecha Desde no puede ser mayor a la fecha Hasta");
        }
    }

}

