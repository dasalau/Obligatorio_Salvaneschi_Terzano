using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.Infraestructura.AccespDatos.EF
{
    public class RepositorioMetodoPago : IRepositorioMetodoPago
    {
        private ObligatorioContext _context;
        public RepositorioMetodoPago(ObligatorioContext context)
        {
            _context = context;
        }

        public void Add(MetodoPago obj)
        {
            // Validar
            _context.MetodosPago.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MetodoPago> GetAll()
        {
            return _context.MetodosPago;
        }

        public MetodoPago GetById(int id)
        {
            MetodoPago unMetodoPago = _context.MetodosPago.FirstOrDefault(metodoPagos => metodoPagos.Id == id);
            if (unMetodoPago == null)
            {
                throw new MetodoPagoExcepcion("No se encontro el método de pago");
            }
            return unMetodoPago;
        }

        public void Update(int id, MetodoPago obj)
        {
            throw new NotImplementedException();
        }
    }
}
