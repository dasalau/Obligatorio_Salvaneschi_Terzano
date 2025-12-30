using Obligatorio.LogicaNegocio.Vo;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Unico : Pagos
    {
        public DateTime FechaPago { get; set; }
        public int NumeroRecibo { get; set; }

        public override double GetSaldo()
        {
            return 0.0;
        }

        protected Unico()
        {
        }

        public Unico(VoDescripcion descripcion,
                     double montoPago,
                     int tipoGastoId,
                     int metodoPagoId,
                     int usuarioId,
                     DateTime fechaPago,
                     int numeroRecibo) : base(descripcion,
                                                 montoPago,
                                                 tipoGastoId,
                                                 metodoPagoId,
                                                 usuarioId)
        {
            FechaPago = fechaPago;
            NumeroRecibo = numeroRecibo;
        }
        //public override void Validable()
        //{
        //    base.Validable();
        //    if (NumeroRecibo <= 0)
        //        throw new PagosExcepcion("El numero de recibo debe ser mayor a cero");
        //}
    }
}
