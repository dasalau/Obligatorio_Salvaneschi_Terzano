using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.Vo;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public abstract class Pagos : IEntity, IValidable
    {
        public int Id { get; set; }
        public VoDescripcion Descripcion { get; set; }

        public double MontoPago { get; set; }
        public TipoGasto TipoGasto { get; set; }
        public int TipoGastoId { get; set; }
        public MetodoPago MetodoPago { get; set; }
        public int MetodoPagoId { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public string Discriminator { get; set; }

        public abstract double GetSaldo();

        protected Pagos()
        {
        }

        public Pagos(VoDescripcion descripcion,
                     double montoPago,
                     int tipoGastoId,
                     int metodoPagoId,
                     int usuarioId)
        {

            Descripcion = descripcion;
            MontoPago = montoPago;
            TipoGastoId = tipoGastoId;
            MetodoPagoId = metodoPagoId;
            UsuarioId = usuarioId;

            Validable();
        }

        public virtual void Validable()
        {
            if (MontoPago <= 0)
                throw new PagosExcepcion("El monto del pago debe ser mayor a cero");

            if (TipoGastoId == 0)
                throw new PagosExcepcion("El tipo de gasto es obligatorio");

            if (MetodoPagoId == 0)
                throw new PagosExcepcion("El metodo de pago es obligatorio");

        }
    }
}
